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
    public partial class MetroFormMain : MetroFramework.Forms.MetroForm
    {
        

        public MetroFormMain()
        {
            InitializeComponent();
        }

        private void Login()
        {
            var formLogin = new FormLogin();
            formLogin.ShowDialog();

            if (Program.UsuarioLogueado != null)
            {
                LabelUsuario.Text = "Usuario: "
                + Program.UsuarioLogueado.Nombre; 
            }
            else
            {
                Application.Exit();
            }
        }

        private void MetroFormMain_Load(object sender, EventArgs e)
        {
            
            metroPanel4_Click(null, e);
            metroPanel4_Click(null, e);
            Login();

        }


        private void AddFormInPanel(Form fh)
        {
            if (this.PanelContedor.Controls.Count > 0)
            {
                this.PanelContedor.Controls.RemoveAt(0);
            }
            Form formacoplada = fh as Form;
            formacoplada.TopLevel = false;
            formacoplada.FormBorderStyle = FormBorderStyle.None;
            formacoplada.Dock = DockStyle.Fill;
            this.PanelContedor.Controls.Add(formacoplada);
            this.PanelContedor.Tag = formacoplada;
            formacoplada.Show();
        }
     
        private void metroTile1_Click(object sender, EventArgs e)
        {
            MetroColor();
            metroTile1.Style = MetroFramework.MetroColorStyle.Green;
            metroTile1.Refresh();
            var form = Application.OpenForms.OfType<FormProductos>().FirstOrDefault();
            FormProductos hijo = form ?? new FormProductos();
            AddFormInPanel(hijo);
            
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            MetroColor();
            metroTile2.Style = MetroFramework.MetroColorStyle.Green;
            metroTile2.Refresh();
            var form = Application.OpenForms.OfType<FormTransacciones>().FirstOrDefault();
            FormTransacciones hijo = form ?? new FormTransacciones();
            AddFormInPanel(hijo);
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            MetroColor();
            metroTile4.Style = MetroFramework.MetroColorStyle.Green;
            metroTile4.Refresh();
            if (metroPanel2.Visible == true)
            {
                metroPanel2.Visible = false;
            }
            else
            {
                metroPanel2.Visible = true;
            }

        }

     
        private void MetroColor()
        {
            metroTile1.Style = MetroFramework.MetroColorStyle.Default;
            metroTile2.Style = MetroFramework.MetroColorStyle.Default;
            metroTile3.Style = MetroFramework.MetroColorStyle.Default;
            metroTile4.Style = MetroFramework.MetroColorStyle.Default;
            metroTile5.Style = MetroFramework.MetroColorStyle.Teal;
            metroTile6.Style = MetroFramework.MetroColorStyle.Teal;
            metroTile7.Style = MetroFramework.MetroColorStyle.Teal;
            this.Refresh();
            
        }

        private void metroTile5_Click_1(object sender, EventArgs e)
        {
            MetroColor();
            metroTile5.Style = MetroFramework.MetroColorStyle.Green;
            metroTile5.Refresh();
            var form = Application.OpenForms.OfType<FormReporteProductos>().FirstOrDefault();
            FormReporteProductos hijo = form ?? new FormReporteProductos();
            AddFormInPanel(hijo);
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            MetroColor();
            metroTile3.Style = MetroFramework.MetroColorStyle.Green;
            metroTile3.Refresh();
            var form = Application.OpenForms.OfType<FormIngres>().FirstOrDefault();
            FormIngres hijo = form ?? new FormIngres();
            AddFormInPanel(hijo);
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            MetroColor();
            metroTile6.Style = MetroFramework.MetroColorStyle.Green;
            metroTile6.Refresh();
            var form = Application.OpenForms.OfType<FormReporteTransacciones>().FirstOrDefault();
            FormReporteTransacciones hijo = form ?? new FormReporteTransacciones();
            AddFormInPanel(hijo);
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            MetroColor();
            metroTile7.Style = MetroFramework.MetroColorStyle.Green;
            metroTile7.Refresh();
            var form = Application.OpenForms.OfType<FormReporteIngreso>().FirstOrDefault();
            FormReporteIngreso hijo = form ?? new FormReporteIngreso();
            AddFormInPanel(hijo);
        }

        private void metroPanel4_Click(object sender, EventArgs e)
        {
            MetroColor();
            var form = Application.OpenForms.OfType<FormInicio>().FirstOrDefault();
            FormInicio hijo = form ?? new FormInicio();
            AddFormInPanel(hijo);
        }
    }
}
