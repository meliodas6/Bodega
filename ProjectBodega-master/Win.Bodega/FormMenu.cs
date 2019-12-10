
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
    public partial class FormMenu : Form
    {

        public FormMenu()
        {
            InitializeComponent();

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
            Login();
            pictureBox1.Hide();
        }

        private void Login()
        {
            var formLogin = new FormLogin();
            formLogin.ShowDialog();
        }

        private void consultaDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            Login();
            pictureBox1.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void salidasDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTransacciones.DefInstance.MdiParent = this;
            FormTransacciones.DefInstance.Show();
        }

        private void reportesDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteProductos = new FormReporteProductos();
            formReporteProductos.MdiParent = this;
            formReporteProductos.Show();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIngres.DefInstance.MdiParent = this;
            FormIngres.DefInstance.Show();
        }

        private void reporteDeTransaccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteTransacciones = new FormReporteTransacciones();
            formReporteTransacciones.MdiParent = this;
            formReporteTransacciones.Show();
        }

        private void reporteGraficoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formGrafico = new FormGrafico();
            formGrafico.MdiParent = this;
            formGrafico.Show();
        }
    }
}
