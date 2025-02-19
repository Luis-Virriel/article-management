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
        private List<Articulo> listaArticulos;

        public Form1()
        {
            InitializeComponent();
            dgvArticulos.SelectionChanged += dgvArticulos_SelectionChanged;
            cargarDatos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Asegúrate de que los artículos se carguen correctamente
            listaArticulos = articuloBLL.ObtenerArticulos();
            if (listaArticulos != null)
            {
                dgvArticulos.DataSource = listaArticulos;
                dgvArticulos.CurrentCell = dgvArticulos.Rows[0].Cells[0];
                configurarColumnas();
            }
            else
            {
                MessageBox.Show("Error: No se pudieron cargar los artículos.");
            }
        }



        private void cargarTodosLosArticulos()
        {
            try
            {
                ArticuloBLL negocio = new ArticuloBLL();
                var listaArticulos = negocio.ObtenerArticulos(); 

                dgvArticulos.DataSource = null;
                dgvArticulos.DataSource = listaArticulos;
                configurarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar todos los artículos: " + ex.Message);
            }
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
                        cargarImagen("https://us.123rf.com/450wm/yehorlisnyi/yehorlisnyi2104/yehorlisnyi210400016/167492439-sin-foto-o-icono-de-imagen-en-blanco-cargando-im%C3%A1genes-o-marca-de-imagen-faltante-imagen-no.jpg");
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
                // Verificar si la URL es válida
                Uri uriResult;
                bool isValidUrl = Uri.TryCreate(imagen, UriKind.Absolute, out uriResult)
                                  && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                // Si la URL es válida, cargar la imagen
                if (isValidUrl)
                {
                    pbFoto.LoadAsync(imagen);
                }
                else
                {
                    // Si no es válida, cargar la imagen predeterminada
                    pbFoto.LoadAsync("https://us.123rf.com/450wm/yehorlisnyi/yehorlisnyi2104/yehorlisnyi210400016/167492439-sin-foto-o-icono-de-imagen-en-blanco-cargando-im%C3%A1genes-o-marca-de-imagen-faltante-imagen-no.jpg");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message);
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
            if (NuevoFormulario.ShowDialog() == DialogResult.OK)
            {
                cargarTodosLosArticulos();
            }
        }

        private void FiltrarDatos(string filtro)
        {
            if (listaArticulos != null && listaArticulos.Count > 0)
            {
                // Filtrar artículos según el filtro (nombre o marca)
                var listaFiltrada = listaArticulos.FindAll(x =>
                    x.Nombre.ToUpper().Contains(filtro.ToUpper()) ||
                    x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper())
                );

                // Asignar la lista filtrada al DataGridView
                dgvArticulos.DataSource = listaFiltrada;
            }
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos(textBoxBuscar.Text);
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    // Obtenemos el artículo seleccionado de la fila activa
                    var articuloSeleccionado = dgvArticulos.CurrentRow?.DataBoundItem as Articulo;

                    if (articuloSeleccionado != null)
                    {
                        // Abrir el formulario para modificar el artículo
                        FormularioCrear formularioModificar = new FormularioCrear(articuloSeleccionado);
                        if (formularioModificar.ShowDialog() == DialogResult.OK)
                        {
                            // Recargar la lista de artículos
                            cargarTodosLosArticulos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El artículo seleccionado no es válido.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un artículo de la lista.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar artículo: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }
        private void eliminar()
        {
            ArticuloBLL negocio = new ArticuloBLL();

            // Obtenemos el artículo seleccionado desde la fila activa
            var seleccionado = dgvArticulos.CurrentRow?.DataBoundItem as Articulo;

            try
            {
                // Verificamos si se ha seleccionado un artículo
                if (seleccionado != null)
                {
                    DialogResult respuesta = MessageBox.Show("¿De verdad querés eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        negocio.eliminar(seleccionado.Id);  // Llamamos a eliminar usando el Id del artículo seleccionado
                        MessageBox.Show("Artículo eliminado correctamente.");

                        cargarTodosLosArticulos();  // Recargamos los datos para reflejar la eliminación
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un artículo para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void textBoxBuscar_TextChanged_1(object sender, EventArgs e)
        {
            // Solo aplicar el filtro si el texto tiene 3 o más caracteres
            if (textBoxBuscar.Text.Length >= 3)
            {
                FiltrarDatos(textBoxBuscar.Text);
            }
            else
            {
                // Si el texto es menor a 3 caracteres, mostrar todos los artículos
                dgvArticulos.DataSource = listaArticulos;
            }
            configurarColumnas();  // Vuelve a configurar las columnas para que no se pierdan
        }
    }
}
