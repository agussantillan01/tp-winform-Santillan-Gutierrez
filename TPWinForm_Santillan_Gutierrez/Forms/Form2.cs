using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Forms
{
    public partial class FormAgregarArticulo : Form
    {
        public FormAgregarArticulo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            Articulo arti = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();



            try
            {
                //  arti.Codigo = int.Parse(txtCodigoArticulo.Text);
                arti.Codigo = txtCodigoArticulo.Text;
                arti.Nombre = txtNombreArticulo.Text;
                arti.Descripcion = txtDescripcion.Text;
                arti.Categoria = (Categoria)cboCategoria.SelectedItem;
                arti.Marca =  (Marca)cboMarca.SelectedItem;

               negocio.agregar(arti);
                MessageBox.Show("Agregado Correctamente");
                Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }
        }

        private void FormAgregarArticulo_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            try
            {
                cboCategoria.DataSource = categoriaNegocio.listar();
                cboMarca.DataSource = marcaNegocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
        }
    }
}
