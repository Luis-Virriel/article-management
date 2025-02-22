using BLL;
using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionFinal
{
    public partial class FormularioCrear : Form
    {
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;
        private Articulo lista = new Articulo();
        public FormularioCrear()
        {
            InitializeComponent();
            
        }
        public FormularioCrear(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar articulo";
        }
        private void btbSalir_Click(object sender, EventArgs e)
        {
            FormularioCrear.ActiveForm.Close();

        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);

        }
        private void cargarImagen(string imagen)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(imagen))
                {
                    pbFotoCrear.LoadAsync(imagen);
                }
                else
                {
                    pbFotoCrear.LoadAsync("https://png.pngtree.com/png-clipart/20210314/original/pngtree-not-loaded-during-loading-png-image_6083139.jpg");
                }
            }
            catch (Exception)
            {
                pbFotoCrear.LoadAsync("https://png.pngtree.com/png-clipart/20210314/original/pngtree-not-loaded-during-loading-png-image_6083139.jpg");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloBLL negocio = new ArticuloBLL();
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
                {
                    MessageBox.Show("Ingrese un precio válido (número positivo).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbMarca.SelectedItem == null || cbCategoria.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar una Marca y una Categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (articulo == null)
                {
                    articulo = new Articulo();
                }
                articulo.Codigo = txtCodigo.Text.Trim();
                articulo.Nombre = txtNombre.Text.Trim();
                articulo.Descripcion = txtDescripcion.Text.Trim();
                articulo.ImagenUrl = txtUrlImagen.Text.Trim();
                articulo.Precio = precio;
                articulo.Marca = (Marca)cbMarca.SelectedItem;
                articulo.Categoria = (Categoria)cbCategoria.SelectedItem;
                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Agregado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FormularioCrear_Load(object sender, EventArgs e)
        {
            ArticuloBLL negocio = new ArticuloBLL();
            try
            {
                cbMarca.DataSource = negocio.ObtenerMarcas();
                cbMarca.ValueMember = "Id";
                cbMarca.DisplayMember = "Descripcion";

                cbCategoria.DataSource = negocio.ObtenerCategorias();
                cbCategoria.ValueMember = "Id";
                cbCategoria.DisplayMember = "Descripcion";

                if (articulo == null)
                {
                    articulo = new Articulo();
                }
                else
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtUrlImagen.Text = articulo.ImagenUrl;
                    txtPrecio.Text = articulo.Precio.ToString("0.00"); 
                    cbMarca.SelectedValue = articulo.Marca?.Id;
                    cbCategoria.SelectedValue = articulo.Categoria?.Id;
                    cargarImagen(articulo.ImagenUrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool soloNumeros(string cadena)
        {
            return !string.IsNullOrEmpty(cadena) && cadena.All(char.IsDigit);
        }



    }
}
