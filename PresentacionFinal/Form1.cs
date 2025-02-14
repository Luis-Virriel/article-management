using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PresentacionFinal
{
    public partial class Form1 : Form
    {
        private ArticuloBLL articuloBLL = new ArticuloBLL();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvArticulos.DataSource = articuloBLL.ObtenerArticulos();
            configurarColumnas();
            cargarDatos();
        }

        private void configurarColumnas()
        {
            dgvArticulos.Columns["Id"].Visible = false; // Ocultamos Id
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            dgvArticulos.Columns["CategoriaDescripcion"].Visible = false;
            dgvArticulos.Columns["Precio"].Visible = false;

            // Mostrar solo lo necesario
            dgvArticulos.Columns["Codigo"].HeaderText = "Código";
            dgvArticulos.Columns["Nombre"].HeaderText = "Nombre";
           // dgvArticulos.Columns["ArticuloDescripcion"].HeaderText = "Descripción";
            dgvArticulos.Columns["MarcaDescripcion"].HeaderText = "Marca";
        }

        private void cargarDatos()
        {
            try
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    textBoxDescripcion.Text = dgvArticulos.CurrentRow.Cells["Descripcion"].Value.ToString();
                    lblMostrarPrecio.Text = dgvArticulos.CurrentRow.Cells["Precio"].Value.ToString();

                    string urlImagen = dgvArticulos.CurrentRow.Cells["ImagenUrl"].Value.ToString();
                    cargarImagen(urlImagen);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }


        private void cargarImagen(string imagen)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagen))
                {
                    pbFoto.Load(imagen);
                }
                else
                {
                    pbFoto.Load("https://via.placeholder.com/300"); // Imagen de respaldo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                pbFoto.Load("https://via.placeholder.com/300"); // Imagen de respaldo en caso de error
            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            cargarDatos();
        }
        /*rivate void FiltrarDatos(string filtro)
        {
            DataTable dt = (DataTable)dgvArticulos.DataSource;
            dt.DefaultView.RowFilter = $"Nombre LIKE '%{filtro}%' OR Codigo LIKE '%{filtro}%'";
        }*/

        /*private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos(textBoxBuscar.Text);
        }*/
    } 
}
