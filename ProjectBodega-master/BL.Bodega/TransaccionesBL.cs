using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bodega
{
    public class TransaccionesBL
    {
        Contexto _contexto;

        public BindingList<Transaccion> ListaTransacciones { get; set; }

        public TransaccionesBL()
        {
            _contexto = new Contexto();
        }

        public BindingList<Transaccion> ObtenerTransacciones()
        {
            _contexto.Transacciones.Include("TransaccionDetalle").Load();
            ListaTransacciones = _contexto.Transacciones.Local.ToBindingList();

            return ListaTransacciones;
        }

        public BindingList<Transaccion> ObtenerTransacciones(DateTime fechaInicio, DateTime fechaFinal)
        {
            var consulta = _contexto.Transacciones
                .Where(r => r.Fecha >= fechaInicio && r.Fecha <= fechaFinal);

            ListaTransacciones = new BindingList<Transaccion>(consulta.ToList());

            return ListaTransacciones;
        }

        public void AgregarTransaccion()
        {
            var nuevaTransaccion = new Transaccion();
            ListaTransacciones.Add(nuevaTransaccion);//REVISAR PORQ NO CONTEXTO
        }
        
        public void AgregarTransaccionDetalle(Transaccion transaccion)
        {
            if (transaccion != null)
            {
                var nuevoDetalle = new TransaccionDetalle();
                transaccion.TransaccionDetalle.Add(nuevoDetalle);
            }
        }

        public void RemoverTransaccionDetalle(Transaccion transaccion, TransaccionDetalle transaccionDetalle)
        {
            if (transaccion != null && transaccionDetalle != null)
            {
                transaccion.TransaccionDetalle.Remove(transaccionDetalle);
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

        public Resultado GuardarTransaccion(Transaccion transaccion)
        {
            

            var resultado = Validar(transaccion);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            CalcularExistenciaEgresos(transaccion);
            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }

        public void CalcularExistenciaEgresos(Transaccion transaccion)
        {
            foreach (var detalle in transaccion.TransaccionDetalle)
            {
                var producto = _contexto.Productos.Find(detalle.ProductoId);
                if (producto != null)
                {
                    if (transaccion.Activo == true) 
                    {
                        producto.Existencia = producto.Existencia - detalle.Cantidad;
                    }
                    else
                    {
                        producto.Existencia = producto.Existencia + detalle.Cantidad;
                    }
                    
                }
            }
        }

       private Resultado Validar(Transaccion transaccion)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (transaccion == null)
            {
                resultado.Mensaje = "Agregue una transaccion para poderla salvar";
                resultado.Exitoso = false;

                return resultado;
            }

            if (transaccion.Id != 0 && transaccion.Activo == true) 
            {
                resultado.Mensaje = "La transaccion ya fue emitida y no se pueden realizar cambios en ella";
                resultado.Exitoso = false;
            }

            if (transaccion.Activo == false)
            {
                resultado.Mensaje = "La transaccion esta anulada no se pueden realizar cambios en ella";
                resultado.Exitoso = false;
            }

            if (transaccion.TransaccionDetalle.Count == 0) 
            {
                resultado.Mensaje = "Agregue productos a la factura";
                resultado.Exitoso = false;
            }
            foreach (var detalle in transaccion.TransaccionDetalle)
            {
                if (detalle.ProductoId == 0) 
                {
                    resultado.Mensaje = "Seleccione productos validos";
                    resultado.Exitoso = false;
                }
            }
      
            return resultado;
        }

        public void CalcularFactura(Transaccion transaccion)
        {
            if (transaccion != null)
            {
                double subtotal = 0;
                foreach (var detalle in transaccion.TransaccionDetalle)
                {
                    var producto = _contexto.Productos.Find(detalle.ProductoId);
                    if (producto != null)
                    {
                        detalle.Precio = producto.Precio;
                        detalle.Total = detalle.Cantidad * producto.Precio;
                        subtotal += detalle.Total;
                    }
                }
                transaccion.Total = subtotal;
            }
        }

        public bool AnularTransaccion(int id)
        {
            foreach (var transaccion in ListaTransacciones)
            {
                if (transaccion.Id == id)
                {
                    transaccion.Activo = false;
                    CalcularExistenciaEgresos(transaccion);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }

    }

    public class Transaccion
    {
        internal DateTime OrderDate;

        public int Id { get; set; }
        //public string Ubicacion { get; set; }
        //public int ProductoId { get; set; }
        //public int Cantidad { get; set; }
        //public int TipoTransaccion { get; set; } //1=Ingreso 2=Egreso 3=Movimiento Interno
        public BindingList<TransaccionDetalle> TransaccionDetalle { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public bool Activo { get; set; }
        
        public Transaccion()
        {
            Fecha = DateTime.Now;
            TransaccionDetalle = new BindingList<TransaccionDetalle>();
            Activo = true;
        }
    }
    public class TransaccionDetalle
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }

        public TransaccionDetalle()
        {
            Cantidad = 1;
        }
    }
}