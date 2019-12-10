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
    public partial class FormReporteIngreso : Form
    {
        public FormReporteIngreso()
        {
            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var _IngresosBL = new IngresBL();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _IngresosBL.ObtenerIngress();

            var reporte = new ReporteInfreso();
            reporte.SetDataSource(bindingSource);
            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fechaInicio = dateTimePicker1.Value;
            var fechaFinal = dateTimePicker2.Value;

            var IngresoBL = new IngresBL();
            var bindingSource = new BindingSource();

            bindingSource.DataSource = IngresoBL
                   .ObtenerIngresoFecha(fechaInicio, fechaFinal);



            var reporte = new ReporteInfreso();
            reporte.SetDataSource(bindingSource);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }
    }
}
