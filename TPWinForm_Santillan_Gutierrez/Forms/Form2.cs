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
        private Articulo articulo = null;
        public FormAgregarArticulo()
        {
            InitializeComponent();
        }
        public FormAgregarArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Articulo arti = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
    
                if (articulo == null)
                    articulo = new Articulo();
                
                //  arti.Codigo = int.Parse(txtCodigoArticulo.Text);
                articulo.Codigo = txtCodigoArticulo.Text;
                articulo.Nombre = txtNombreArticulo.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.Marca =  (Marca)cboMarca.SelectedItem;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                articulo.ImagenUrl = txtImagenUrl.Text;

                if (articulo.Id != 0)
                {

                negocio.Modificar(articulo);
                MessageBox.Show("Modificado Correctamente");

                }
                else
                {
                    if (articulo.Precio > 0 && articulo.Codigo.Length >2 && articulo.Descripcion.Length >2)
                    {
                       negocio.agregar(articulo);
                       MessageBox.Show("Agregado Correctamente");

                    }
                    else
                    {
                        MessageBox.Show("Revise los datos ingresados...");
                    }

                }


                Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Los datos ingresados son incorrectos o no ingreso ningun dato");

            }
        }

        private void FormAgregarArticulo_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            try
            {
                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Tipo";
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "nombreMarca";

                if (articulo !=null)
                {
                    txtCodigoArticulo.Text = articulo.Codigo;
                    txtNombreArticulo.Text= articulo.Nombre;
                    txtDescripcion.Text= articulo.Descripcion;
                    txtImagenUrl.Text = articulo.ImagenUrl;
                    cargarImagen(articulo.ImagenUrl);
                    txtPrecio.Text = articulo.Precio.ToString();
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCategoria.SelectedValue = articulo.Marca.Id;




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
        }


        private void cargarImagen(string linkImg)
        {
            try
            {
                picboxArticulo.Load(linkImg);
            }
            catch (Exception)
            {
                picboxArticulo.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");


            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtImagenUrl.Text);
        }


    }
}
