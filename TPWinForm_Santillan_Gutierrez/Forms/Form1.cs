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

        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                articuloList = negocio.listar();
                dgvComercio.DataSource = articuloList;
                dgvComercio.Columns["ImagenUrl"].Visible = false;
                cargarImagen(articuloList[0].ImagenUrl);

                dgvComercio.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           FormAgregarArticulo ventana = new FormAgregarArticulo();
            ventana.ShowDialog();
            cargar();
        }


        private void FormPrincipal_Load(object sender, EventArgs e)
        {

            cargar();
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
                picboxArticulo.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");


            }
        }

        private void dgvComercio_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                object value = dgvComercio.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dgvComercio.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dgvComercio.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvComercio.CurrentRow.DataBoundItem;

            FormAgregarArticulo modificar = new FormAgregarArticulo(seleccionado);
            modificar.ShowDialog();
            cargar();
        }
    }
}
