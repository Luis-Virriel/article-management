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
                if (articulo == null)
                {
                    articulo = new Articulo();
                }

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.ImagenUrl = txtUrlImagen.Text;
                articulo.Precio = Convert.ToDecimal(txtPrecio.Text);
                articulo.Marca = (Marca)cbMarca.SelectedItem;
                articulo.Categoria = (Categoria)cbCategoria.SelectedItem;

                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.agregar(articulo); 
                    MessageBox.Show("Agregado exitosamente");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
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

                /*if (negocio != null)
                {
                    articulo.Codigo = txtCodigo.Text;
                    articulo.Nombre = txtNombre.Text;
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.ImagenUrl = txtUrlImagen.Text;
                    //cargarImagen(negocio.Url);
                    cbMarca.SelectedValue = articulo.Marca.Id;
                    cbCategoria.SelectedValue = articulo.Categoria.Id;
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
    }
}
