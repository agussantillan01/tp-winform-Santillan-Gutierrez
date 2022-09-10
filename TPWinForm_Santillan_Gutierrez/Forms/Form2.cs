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

               negocio.agregar(arti);
                MessageBox.Show("Agregado Correctamente");
                Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }
        }


    }
}
