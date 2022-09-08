using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion= new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT CODIGO,NOMBRE,Descripcion,ImagenUrl,Precio FROM ARTICULOS";
                comando.Connection = conexion;  
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                   Articulo art = new Articulo();
                    art.Codigo = (string)lector["CODIGO"];
                    art.Nombre = (string)lector["NOMBRE"];
                    art.Descripcion = (string)lector["Descripcion"];
                    art.ImagenUrl = (string)lector["ImagenUrl"];
                    art.Precio = (decimal)lector["Precio"];


                    lista.Add(art);
                }

                //conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            
        }

    }
}
