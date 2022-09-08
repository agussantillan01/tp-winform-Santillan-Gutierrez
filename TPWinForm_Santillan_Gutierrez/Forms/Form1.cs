using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using dominio;
using negocio;

namespace Forms
{
    public partial class FormPrincipal : Form
    {
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
            AccesoDatos negocios = new AccesoDatos();
            dgvComercio.DataSource = negocios.Listar();

        }
    }
}
