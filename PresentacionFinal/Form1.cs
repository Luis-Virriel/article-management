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
        //private List<Articulo> listaArticulo;

        public Form1()
        {
            InitializeComponent();
            dgvArticulos.SelectionChanged += dgvArticulos_SelectionChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvArticulos.DataSource = articuloBLL.ObtenerArticulos();
            configurarColumnas();
            cargarDatos();
        }

        private void configurarColumnas()
        {
            // Ocultar las columnas innecesarias
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            dgvArticulos.Columns["Precio"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false; 
          
            dgvArticulos.Columns["Codigo"].HeaderText = "Código";
            dgvArticulos.Columns["Nombre"].HeaderText = "Nombre";
            
        }

        private void cargarDatos()
        {
            try
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    textBoxDescripcion.Text = dgvArticulos.CurrentRow.Cells["Descripcion"].Value?.ToString() ?? "";
                    lblMostrarPrecio.Text = dgvArticulos.CurrentRow.Cells["Precio"].Value?.ToString() ?? "0.00";

                    string urlImagen = dgvArticulos.CurrentRow.Cells["ImagenUrl"].Value?.ToString();

                    if (!string.IsNullOrEmpty(urlImagen))
                    {
                        cargarImagen(urlImagen);
                    }
                    else
                    {
                        cargarImagen("hthttps://us.123rf.com/450wm/yehorlisnyi/yehorlisnyi2104/yehorlisnyi210400016/167492439-sin-foto-o-icono-de-imagen-en-blanco-cargando-im%C3%A1genes-o-marca-de-imagen-faltante-imagen-no.jpg");
                    }
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
                if (!string.IsNullOrWhiteSpace(imagen))
                {
                    pbFoto.LoadAsync(imagen);
                }
                else
                {
                    pbFoto.LoadAsync("https://us.123rf.com/450wm/yehorlisnyi/yehorlisnyi2104/yehorlisnyi210400016/167492439-sin-foto-o-icono-de-imagen-en-blanco-cargando-im%C3%A1genes-o-marca-de-imagen-faltante-imagen-no.jpg");
                }
            }
            catch (Exception)
            {
                pbFoto.LoadAsync("https://us.123rf.com/450wm/yehorlisnyi/yehorlisnyi2104/yehorlisnyi210400016/167492439-sin-foto-o-icono-de-imagen-en-blanco-cargando-im%C3%A1genes-o-marca-de-imagen-faltante-imagen-no.jpg");
            }
        }


        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    var seleccionado = dgvArticulos.CurrentRow.DataBoundItem as Articulo;
                    if (seleccionado != null)
                    {
                        textBoxDescripcion.Text = seleccionado.Descripcion;
                        lblMostrarPrecio.Text = seleccionado.Precio.ToString("C");

                        string urlImagen = seleccionado.ImagenUrl;

                        if (string.IsNullOrWhiteSpace(urlImagen) || !Uri.IsWellFormedUriString(urlImagen, UriKind.Absolute))
                        {
                            urlImagen = "https://us.123rf.com/450wm/yehorlisnyi/yehorlisnyi2104/yehorlisnyi210400016/167492439-sin-foto-o-icono-de-imagen-en-blanco-cargando-im%C3%A1genes-o-marca-de-imagen-faltante-imagen-no.jpg";
                        }

                        cargarImagen(urlImagen);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar de selección: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormularioCrear NuevoFormulario = new FormularioCrear();
            NuevoFormulario.ShowDialog();
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
