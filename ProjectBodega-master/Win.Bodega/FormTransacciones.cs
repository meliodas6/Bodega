using BL.Bodega;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Bodega
{
    public partial class FormTransacciones : Form
    {
        TransaccionesBL _transacciones;
        ProductosBL _productos;
        
        public FormTransacciones()
        {
            InitializeComponent();

           _transacciones = new TransaccionesBL();
            listaTransaccionesBindingSource.DataSource = _transacciones.ObtenerTransacciones();
            _productos = new ProductosBL();
            listaProductosBindingSource.DataSource = _productos.ObtenerProductos();
            
        }

        private static FormTransacciones m_FormDefInstance;
        /// 
        /// Crea una instancia unica del Formulario
        /// 
        /// Instancia por defecto
        public static FormTransacciones DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new FormTransacciones();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _transacciones.AgregarTransaccion();
            listaTransaccionesBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
            DeshabilitarHabilitarTextbox(true);
            listaTransaccionesBindingNavigatorSaveItem.Enabled = true;
        }
               
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea anular esta transaccion?", "Anular", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Anular(id);
                }
            }
        }

        private void Anular(int id)
        {
            var resultado = _transacciones.AnularTransaccion(id);
            if (resultado == true)
            {
                listaTransaccionesBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al anular la factura");
            }
        }

        private void listaTransaccionesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaTransaccionesBindingSource.EndEdit();
            var transaccion = (Transaccion)listaTransaccionesBindingSource.Current;

            var resultado = _transacciones.GuardarTransaccion(transaccion);

           if (resultado.Exitoso == true)
            {
                listaTransaccionesBindingSource.ResetBindings(false);//REVISAR DEBERIA SER LISTRANS
                DeshabilitarHabilitarBotones(true);
                DeshabilitarHabilitarTextbox(false);
                MessageBox.Show("Datos Guardados");
                listaTransaccionesBindingNavigatorSaveItem.Enabled = false;
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            DeshabilitarHabilitarTextbox(false);
            _transacciones.CancelarCambios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Transaccion = (Transaccion)listaTransaccionesBindingSource.Current;
            _transacciones.AgregarTransaccionDetalle(Transaccion);
            DeshabilitarHabilitarBotones(false);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Transaccion = (Transaccion)listaTransaccionesBindingSource.Current;
            var TransaccionDetalle = (TransaccionDetalle)transaccionDetalleBindingSource.Current;
            _transacciones.RemoverTransaccionDetalle(Transaccion, TransaccionDetalle);
            DeshabilitarHabilitarBotones(false);
        }

        private void transaccionDetalleDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void transaccionDetalleDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var Transaccion = (Transaccion)listaTransaccionesBindingSource.Current;
            _transacciones.CalcularFactura(Transaccion);
            listaTransaccionesBindingSource.ResetBindings(false);
            DeshabilitarHabilitarBotones(false);
        }

        private void listaTransaccionesBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var Transaccion = (Transaccion)listaTransaccionesBindingSource.Current;
            if (Transaccion != null && Transaccion.Id != 0 && Transaccion.Activo == false) 
            {
                label1.Visible = true;
            }
            else
            {
                label1.Visible = false;
            }
        }

        private void FormTransacciones_Load(object sender, EventArgs e)
        {
            DeshabilitarHabilitarTextbox(false);
            listaTransaccionesBindingNavigatorSaveItem.Enabled = false;
        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;//Antepuesto(negacion, si es V es F, y si es F es V)
        }

        private void DeshabilitarHabilitarTextbox(bool valor)
        {
            button2.Enabled = valor;
            button3.Enabled = valor;
            transaccionDetalleDataGridView.ReadOnly = !valor;
            fechaDateTimePicker.Enabled = valor;
        }
    }
}
