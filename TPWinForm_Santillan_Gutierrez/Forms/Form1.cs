using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace Forms
{
    public partial class FormPrincipal : Form
    {
        private List<Articulo> articuloList;
        public FormPrincipal()
        {
            InitializeComponent();
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
           FormAgregarArticulo ventana = new FormAgregarArticulo();
            ventana.ShowDialog();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            articuloList = negocio.listar();
            dgvComercio.DataSource = articuloList;
            dgvComercio.Columns["ImagenUrl"].Visible = false;
            cargarImagen(articuloList[0].ImagenUrl);

        }
        private void dgvComercio_SelectionChanged(object sender, EventArgs e)
        {

            Articulo selec = (Articulo)dgvComercio.CurrentRow.DataBoundItem;
            cargarImagen(selec.ImagenUrl);

        }

        private void cargarImagen(string linkImg)
        {
            try
            {
                picboxArticulo.Load(linkImg);
            }
            catch (Exception ex)
            {
                picboxArticulo.Load("https://embacal.com/wp-content/uploads/2018/11/no-photo-available.png");


            }
        }

    }
}
