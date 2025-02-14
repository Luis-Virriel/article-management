namespace PresentacionFinal
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblMostrarPrecio = new System.Windows.Forms.Label();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.textBoxMarca = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBoxPrecioInicial = new System.Windows.Forms.TextBox();
            this.textBoxPrecioFinal = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lvlCategoria = new System.Windows.Forms.Label();
            this.listViewArticulos = new System.Windows.Forms.ListView();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFoto
            // 
            this.pbFoto.Location = new System.Drawing.Point(350, 34);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(514, 516);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFoto.TabIndex = 0;
            this.pbFoto.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(484, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(188, 13);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Bienvenidos al catálogo de productos.";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(225, 291);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(13, 13);
            this.lblPrecio.TabIndex = 2;
            this.lblPrecio.Text = "$";
            this.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMostrarPrecio
            // 
            this.lblMostrarPrecio.AutoSize = true;
            this.lblMostrarPrecio.Location = new System.Drawing.Point(244, 291);
            this.lblMostrarPrecio.Name = "lblMostrarPrecio";
            this.lblMostrarPrecio.Size = new System.Drawing.Size(25, 13);
            this.lblMostrarPrecio.TabIndex = 4;
            this.lblMostrarPrecio.Text = "dad";
            // 
            // lblArticulo
            // 
            this.lblArticulo.AutoSize = true;
            this.lblArticulo.Location = new System.Drawing.Point(276, 55);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(44, 13);
            this.lblArticulo.TabIndex = 5;
            this.lblArticulo.Text = "Artículo";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(883, 633);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(96, 13);
            this.lblBuscar.TabIndex = 6;
            this.lblBuscar.Text = "Buscar por nombre";
            // 
            // textBoxBuscar
            // 
            this.textBoxBuscar.Location = new System.Drawing.Point(985, 627);
            this.textBoxBuscar.Name = "textBoxBuscar";
            this.textBoxBuscar.Size = new System.Drawing.Size(193, 20);
            this.textBoxBuscar.TabIndex = 7;
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(356, 571);
            this.textBoxDescripcion.Multiline = true;
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.ReadOnly = true;
            this.textBoxDescripcion.Size = new System.Drawing.Size(508, 70);
            this.textBoxDescripcion.TabIndex = 8;
            // 
            // textBoxMarca
            // 
            this.textBoxMarca.Location = new System.Drawing.Point(1255, 567);
            this.textBoxMarca.Name = "textBoxMarca";
            this.textBoxMarca.Size = new System.Drawing.Size(100, 20);
            this.textBoxMarca.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(1255, 593);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 10;
            // 
            // textBoxPrecioInicial
            // 
            this.textBoxPrecioInicial.Location = new System.Drawing.Point(1255, 627);
            this.textBoxPrecioInicial.Name = "textBoxPrecioInicial";
            this.textBoxPrecioInicial.Size = new System.Drawing.Size(65, 20);
            this.textBoxPrecioInicial.TabIndex = 11;
            // 
            // textBoxPrecioFinal
            // 
            this.textBoxPrecioFinal.Location = new System.Drawing.Point(1376, 627);
            this.textBoxPrecioFinal.Name = "textBoxPrecioFinal";
            this.textBoxPrecioFinal.Size = new System.Drawing.Size(65, 20);
            this.textBoxPrecioFinal.TabIndex = 12;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(1209, 574);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(37, 13);
            this.lblMarca.TabIndex = 13;
            this.lblMarca.Text = "Marca";
            // 
            // lvlCategoria
            // 
            this.lvlCategoria.AutoSize = true;
            this.lvlCategoria.Location = new System.Drawing.Point(1195, 600);
            this.lvlCategoria.Name = "lvlCategoria";
            this.lvlCategoria.Size = new System.Drawing.Size(54, 13);
            this.lvlCategoria.TabIndex = 14;
            this.lvlCategoria.Text = "Categoría";
            // 
            // listViewArticulos
            // 
            this.listViewArticulos.HideSelection = false;
            this.listViewArticulos.Location = new System.Drawing.Point(1091, 34);
            this.listViewArticulos.Name = "listViewArticulos";
            this.listViewArticulos.Size = new System.Drawing.Size(375, 516);
            this.listViewArticulos.TabIndex = 16;
            this.listViewArticulos.UseCompatibleStateImageBehavior = false;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(1372, 567);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(80, 51);
            this.btnFiltrar.TabIndex = 17;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1202, 630);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Desde $";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1326, 630);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Hasta $";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 652);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.listViewArticulos);
            this.Controls.Add(this.lvlCategoria);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.textBoxPrecioFinal);
            this.Controls.Add(this.textBoxPrecioInicial);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBoxMarca);
            this.Controls.Add(this.textBoxDescripcion);
            this.Controls.Add(this.textBoxBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.lblArticulo);
            this.Controls.Add(this.lblMostrarPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pbFoto);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblMostrarPrecio;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox textBoxBuscar;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.TextBox textBoxMarca;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBoxPrecioInicial;
        private System.Windows.Forms.TextBox textBoxPrecioFinal;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lvlCategoria;
        private System.Windows.Forms.ListView listViewArticulos;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

