namespace Win.Bodega
{
    partial class FormMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeEspacioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salidasDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeTransaccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteGraficoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Ivory;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientoToolStripMenuItem,
            this.transaccionToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(464, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mantenimientoToolStripMenuItem
            // 
            this.mantenimientoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaDeProductoToolStripMenuItem,
            this.consultaDeEspacioToolStripMenuItem});
            this.mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
            this.mantenimientoToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.mantenimientoToolStripMenuItem.Text = "Mantenimiento";
            // 
            // consultaDeProductoToolStripMenuItem
            // 
            this.consultaDeProductoToolStripMenuItem.Name = "consultaDeProductoToolStripMenuItem";
            this.consultaDeProductoToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.consultaDeProductoToolStripMenuItem.Text = "Productos";
            this.consultaDeProductoToolStripMenuItem.Click += new System.EventHandler(this.consultaDeProductoToolStripMenuItem_Click);
            // 
            // consultaDeEspacioToolStripMenuItem
            // 
            this.consultaDeEspacioToolStripMenuItem.Name = "consultaDeEspacioToolStripMenuItem";
            this.consultaDeEspacioToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.consultaDeEspacioToolStripMenuItem.Text = "Consulta de Espacio en Bodega";
            // 
            // transaccionToolStripMenuItem
            // 
            this.transaccionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salidasDeProductosToolStripMenuItem,
            this.ingresosToolStripMenuItem});
            this.transaccionToolStripMenuItem.Name = "transaccionToolStripMenuItem";
            this.transaccionToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.transaccionToolStripMenuItem.Text = "Transaccion";
            // 
            // salidasDeProductosToolStripMenuItem
            // 
            this.salidasDeProductosToolStripMenuItem.Name = "salidasDeProductosToolStripMenuItem";
            this.salidasDeProductosToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.salidasDeProductosToolStripMenuItem.Text = "Egresos";
            this.salidasDeProductosToolStripMenuItem.Click += new System.EventHandler(this.salidasDeProductosToolStripMenuItem_Click);
            // 
            // ingresosToolStripMenuItem
            // 
            this.ingresosToolStripMenuItem.Name = "ingresosToolStripMenuItem";
            this.ingresosToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.ingresosToolStripMenuItem.Text = "Ingresos";
            this.ingresosToolStripMenuItem.Click += new System.EventHandler(this.ingresosToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportesDeProductosToolStripMenuItem,
            this.reporteDeTransaccionesToolStripMenuItem,
            this.reporteGraficoToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // reportesDeProductosToolStripMenuItem
            // 
            this.reportesDeProductosToolStripMenuItem.Name = "reportesDeProductosToolStripMenuItem";
            this.reportesDeProductosToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.reportesDeProductosToolStripMenuItem.Text = "Reportes de Productos";
            this.reportesDeProductosToolStripMenuItem.Click += new System.EventHandler(this.reportesDeProductosToolStripMenuItem_Click);
            // 
            // reporteDeTransaccionesToolStripMenuItem
            // 
            this.reporteDeTransaccionesToolStripMenuItem.Name = "reporteDeTransaccionesToolStripMenuItem";
            this.reporteDeTransaccionesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.reporteDeTransaccionesToolStripMenuItem.Text = "Reporte de Transacciones";
            this.reporteDeTransaccionesToolStripMenuItem.Click += new System.EventHandler(this.reporteDeTransaccionesToolStripMenuItem_Click);
            // 
            // reporteGraficoToolStripMenuItem
            // 
            this.reporteGraficoToolStripMenuItem.Name = "reporteGraficoToolStripMenuItem";
            this.reporteGraficoToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.reporteGraficoToolStripMenuItem.Text = "Reporte Grafico";
            this.reporteGraficoToolStripMenuItem.Click += new System.EventHandler(this.reporteGraficoToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.ayudaToolStripMenuItem.Text = "Seguridad";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Win.Bodega.Properties.Resources.a3c851a3_c6bc_42b2_99ff_f0b8b7e56a88;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(464, 285);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(464, 309);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMenu";
            this.Text = "Menu de Trabajo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaDeProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaDeEspacioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transaccionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salidasDeProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesDeProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeTransaccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteGraficoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}