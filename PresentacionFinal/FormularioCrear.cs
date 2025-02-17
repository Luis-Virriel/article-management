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
        public FormularioCrear()
        {
            InitializeComponent();
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
    }
}
