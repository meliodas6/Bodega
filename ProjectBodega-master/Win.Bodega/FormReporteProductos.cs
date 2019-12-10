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
    public partial class FormReporteProductos : Form
    {
        public FormReporteProductos()
        {
            InitializeComponent();
            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.Hide();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var _productoBL = new ProductosBL();
            var bindingSource = new BindingSource();
            var tipoProducto = textBox1.Text;

            if (!string.IsNullOrEmpty(tipoProducto))
            {
                bindingSource.DataSource = _productoBL.ObtenerProductosP(tipoProducto);
            
            }
            else
            {
                bindingSource.DataSource = _productoBL.ObtenerProductos();
            }
            

            var reporte = new ReporteProducto();
            reporte.SetDataSource(bindingSource);
            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
            crystalReportViewer1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
   
            
        }
    }
}
