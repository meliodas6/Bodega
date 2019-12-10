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
    public partial class FormLogin : MetroFramework.Forms.MetroForm
    {
        SeguridadBL _seguridad;

        public FormLogin()
        {
            InitializeComponent();

            _seguridad = new SeguridadBL();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario;
            string contrasena;

            usuario = metroTextBox1.Text;
            contrasena = metroTextBox2.Text;

            button1.Enabled = false;
            button1.Text = "Verificando......";
            Application.DoEvents();

            var usuarioDB = _seguridad.Autorizar(usuario, contrasena);

            if (usuarioDB != null)
            {
                Program.UsuarioLogueado = usuarioDB;

                this.Close();
            }

            else
            { 

                MessageBox.Show("El usuario o la contraseña son incorrectas");
            }
            button1.Text = "Ingresar";
            button1.Enabled = true;
        }
     
        private void button1_Enter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.user;
            panel1.BackColor = Color.Red;

            pictureBox3.BackgroundImage = Properties.Resources.pass;
            panel2.BackColor = Color.Red;

        }

        private void button2_Enter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.user;
            panel1.BackColor = Color.Red;
           
            pictureBox3.BackgroundImage = Properties.Resources.pass;
            panel2.BackColor = Color.Red;
        }
        
        private void FormLogin_Load(object sender, EventArgs e)
        {
            button1.Select();
            button1.Focus();
        }

        private void metroTextBox1_Enter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.user___copia;
            panel1.BackColor = Color.FromArgb(77, 210, 255);

            pictureBox3.BackgroundImage = Properties.Resources.pass;
            panel2.BackColor = Color.Red;
        }

        private void metroTextBox2_Enter(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.pass___copia;
            panel2.BackColor = Color.FromArgb(77, 210, 255);

            pictureBox2.BackgroundImage = Properties.Resources.user;
            panel1.BackColor = Color.Red;
        }

        private void metroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)
                && !string.IsNullOrEmpty(metroTextBox1.Text))
            {
                metroTextBox2.Focus();
            }
        }

        private void metroTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)
                && !string.IsNullOrEmpty(metroTextBox2.Text))
            {
                button1.Focus();
                button1.PerformClick();
            }
        }
    }
}
