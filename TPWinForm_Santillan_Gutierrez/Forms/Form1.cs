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

        private void ocultarColumnas()
        {
            dgvComercio.Columns["ImagenUrl"].Visible = false;
            dgvComercio.Columns["Id"].Visible = false;
            dgvComercio.Columns["Marca"].Visible = false;
            dgvComercio.Columns["Categoria"].Visible = false;
            dgvComercio.Columns["Codigo"].Visible = false;
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
        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                articuloList = negocio.listar();
                dgvComercio.DataSource = articuloList;
                ocultarColumnas();
                cargarImagen(articuloList[0].ImagenUrl);
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
            cboxCampo.Items.Add("Nombre");
            cboxCampo.Items.Add("Marca");
            cboxCampo.Items.Add("Categoria");
            cboxCampo.Items.Add("Precio");

        }
        private void dgvComercio_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvComercio.CurrentRow != null)
            {

            Articulo selec = (Articulo)dgvComercio.CurrentRow.DataBoundItem;
            cargarImagen(selec.ImagenUrl);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;

            try
            {
                DialogResult respuesta = MessageBox.Show("¿Realmente quiere eliminar?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (respuesta == DialogResult.Yes)

                {
                seleccionado = (Articulo)dgvComercio.CurrentRow.DataBoundItem;
                negocio.Eliminar(seleccionado.Id);
                cargar();
                }

            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.ToString());
            }
        }

        private void cboxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboxCampo.SelectedItem.ToString();
            if (opcion == "Precio")
            {
                cboxCriterio.Items.Clear();
                cboxCriterio.Items.Add("Mayor a");
                cboxCriterio.Items.Add("Menor a");
                cboxCriterio.Items.Add("Igual a");

            }
            else
            {
                cboxCriterio.Items.Clear();
                cboxCriterio.Items.Add("Comienza con");
                cboxCriterio.Items.Add("Termina con");
                cboxCriterio.Items.Add("Contiene");

            } 

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
               
            try
            {
            string campo = cboxCampo.SelectedItem.ToString();
            string criterio = cboxCriterio.SelectedItem.ToString();
            string filtro = txtFiltro.Text;
                dgvComercio.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
        private void txtboxFiltroRapido_TextChanged(object sender, EventArgs e)
        {

            List<Articulo> listaFiltrada;
            string filtro = txtboxFiltroRapido.Text;

            if (filtro != "")
            {
                listaFiltrada = articuloList.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            } else
            {
                listaFiltrada=articuloList;
            }
            dgvComercio.DataSource = null;
            dgvComercio.DataSource = listaFiltrada;
            ocultarColumnas();


        }

        private void btnVerTodo_Click(object sender, EventArgs e)
        {
            if (dgvComercio.Columns["Marca"].Visible == false)
            {
                cargar();
                dgvComercio.Columns["Marca"].Visible = true;
                dgvComercio.Columns["Categoria"].Visible = true;
                dgvComercio.Columns["Codigo"].Visible = true;
                this.btnVerTodo.Text = "Ver menos";
            }
            else
            {
                this.btnVerTodo.Text = "Ver Todo";
                cargar();
            }
        }
    }
}
