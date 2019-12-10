using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bodega
{
    public class IngresBL
    {
        Contexto _contexto;

        public BindingList<Ingres> ListaIngress { get; set; }

        public IngresBL()
        {
            _contexto = new Contexto();
        }

        public BindingList<Ingres> ObtenerIngress()
        {
            _contexto.Ingress.Include("IngresDetalle").Load();
            ListaIngress = _contexto.Ingress.Local.ToBindingList();

            return ListaIngress;
        }

        public BindingList<Ingres> ObtenerIngresoFecha(DateTime fechaInicio, DateTime fechaFinal)
        {
            var consulta = _contexto.Ingress
                .Where(r => r.Fecha >= fechaInicio && r.Fecha <= fechaFinal);

            ListaIngress = new BindingList<Ingres>(consulta.ToList());

            return ListaIngress;
        }

        public void AgregarIngres()
        {
            var nuevaIngres = new Ingres();
            ListaIngress.Add(nuevaIngres);//REVISAR PORQ NO CONTEXTO
        }

        public void AgregarIngresDetalle(Ingres ingres)
        {
            if (ingres != null)
            {
                var nuevoDetalle = new IngresDetalle();
                ingres.IngresDetalle.Add(nuevoDetalle);
            }
        }

        public void RemoverIngresDetalle(Ingres ingres, IngresDetalle ingresDetalle)
        {
            if (ingres != null && ingresDetalle != null)
            {
                ingres.IngresDetalle.Remove(ingresDetalle);
            }
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

        public Resultado GuardarIngres(Ingres ingres)
        {
            var resultado = Validar(ingres);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            CalcularExistenciaIngres(ingres);
            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }

        public void CalcularExistenciaIngres(Ingres ingres)
        {
            foreach (var detalle in ingres.IngresDetalle)
            {
                var producto = _contexto.Productos.Find(detalle.ProductoId);
                if (producto != null)
                {
                    if (ingres.Activo == true)
                    {
                        producto.Existencia = producto.Existencia + detalle.Cantidad;
                    }
                    else
                    {
                        producto.Existencia = producto.Existencia - detalle.Cantidad;
                    }

                }
            }
        }

        private Resultado Validar(Ingres ingres)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (ingres == null)
            {
                resultado.Mensaje = "Agregue una transaccion para poderla salvar";
                resultado.Exitoso = false;

                return resultado;
            }

            if (ingres.Id != 0 && ingres.Activo == true)
            {
                resultado.Mensaje = "La transaccion ya fue emitida y no se pueden realizar cambios en ella";
                resultado.Exitoso = false;
            }

            if (ingres.Activo == false)
            {
                resultado.Mensaje = "La transaccion esta anulada no se pueden realizar cambios en ella";
                resultado.Exitoso = false;
            }

            if (ingres.IngresDetalle.Count == 0)
            {
                resultado.Mensaje = "Agregue productos a la factura";
                resultado.Exitoso = false;
            }
            foreach (var detalle in ingres.IngresDetalle)
            {
                if (detalle.ProductoId == 0)
                {
                    resultado.Mensaje = "Seleccione productos validos";
                    resultado.Exitoso = false;
                }
            }

            return resultado;
        }

        public void CalcularFactura(Ingres ingres)
        {
            if (ingres != null)
            {
                double subtotal = 0;
                foreach (var detalle in ingres.IngresDetalle)
                {
                    var producto = _contexto.Productos.Find(detalle.ProductoId);
                    if (producto != null)
                    {
                        detalle.Precio = producto.Precio;
                        detalle.Total = detalle.Cantidad * producto.Precio;
                        subtotal += detalle.Total;
                    }
                }
                ingres.Total = subtotal;
            }
        }

        public bool AnularIngres(int id)
        {
            foreach (var ingres in ListaIngress)
            {
                if (ingres.Id == id)
                {
                    ingres.Activo = false;
                    CalcularExistenciaIngres(ingres);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }

    }

    public class Ingres
    {
        public int Id { get; set; }
        //public string Ubicacion { get; set; }
        //public int ProductoId { get; set; }
        //public int Cantidad { get; set; }
        //public int TipoIngres { get; set; } //1=Ingreso 2=Egreso 3=Movimiento Interno
        public BindingList<IngresDetalle> IngresDetalle { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public bool Activo { get; set; }

        public Ingres()
        {
            Fecha = DateTime.Now;
            IngresDetalle = new BindingList<IngresDetalle>();
            Activo = true;
        }
    }
    public class IngresDetalle
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }

        public IngresDetalle()
        {
            Cantidad = 1;
        }
    }
}
