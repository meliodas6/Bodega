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
    public partial class FormIngres : Form
    {
        IngresBL _ingresBL;
        ProductosBL _productosBL;

        public FormIngres()
        {
            InitializeComponent();
            _ingresBL = new IngresBL();
            listaIngressBindingSource.DataSource = _ingresBL.ObtenerIngress();

            _productosBL = new ProductosBL();
            listaProductosBindingSource.DataSource = _productosBL.ObtenerProductos();
        }
        
        private static FormIngres m_FormDefInstance;
        /// 
        /// Crea una instancia unica del Formulario
        /// 
        /// Instancia por defecto
        public static FormIngres DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new FormIngres();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _ingresBL.AgregarIngres();
            listaIngressBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
            DeshabilitarHabilitarTextbox(true);
            listaIngressBindingNavigatorSaveItem.Enabled = true;
        }

        private void listaIngressBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaIngressBindingSource.EndEdit();
            var ingres = (Ingres)listaIngressBindingSource.Current;

            var resultado = _ingresBL.GuardarIngres(ingres);

            if (resultado.Exitoso == true)
            {
                listaIngressBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                DeshabilitarHabilitarTextbox(false);
                MessageBox.Show("Datos Guardados");
                listaIngressBindingNavigatorSaveItem.Enabled = false;
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
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
            button1.Enabled = valor;
            button2.Enabled = valor;
            ingresDetalleDataGridView.ReadOnly = !valor;
            fechaDateTimePicker.Enabled = valor;
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            DeshabilitarHabilitarTextbox(false);
            _ingresBL.CancelarCambios();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Ingres = (Ingres)listaIngressBindingSource.Current;
            _ingresBL.AgregarIngresDetalle(Ingres);
            DeshabilitarHabilitarBotones(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Ingres = (Ingres)listaIngressBindingSource.Current;
            var IngresDetalle = (IngresDetalle)ingresDetalleBindingSource.Current;
            _ingresBL.RemoverIngresDetalle(Ingres, IngresDetalle);
            DeshabilitarHabilitarBotones(false);
        }

        private void ingresDetalleDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void ingresDetalleDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var Ingres = (Ingres)listaIngressBindingSource.Current;
            _ingresBL.CalcularFactura(Ingres);
            listaIngressBindingSource.ResetBindings(false);
            DeshabilitarHabilitarBotones(false);
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
            var resultado = _ingresBL.AnularIngres(id);
            if (resultado == true)
            {
                listaIngressBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al anular la factura");
            }
        }

        private void listaIngressBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var Ingres = (Ingres)listaIngressBindingSource.Current;
            if (Ingres != null && Ingres.Id != 0 && Ingres.Activo == false)
            {
                label1.Visible = true;
            }
            else
            {
                label1.Visible = false;
            }
        }
    }
}
