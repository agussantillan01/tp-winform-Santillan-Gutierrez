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
                comando.CommandText = "SELECT A.CODIGO, A.Nombre,A.Descripcion,M.Descripcion AS Marca,C.Descripcion AS TIPO,A.ImagenUrl, A.Precio FROM ARTICULOS A LEFT JOIN MARCAS M ON M.ID= A.IDMARCA LEFT JOIN CATEGORIAS C ON C.ID= A.IdCategoria\r\n";
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

                    art.Marca = new Marca();
                    art.Marca.NombreMarca = (string)lector["Marca"];

                    art.Categoria = new Categoria();

                    //SI EL TIPO DE ARTICULO NO ES NULO LO LEE
                    if (!(lector["TIPO"]is DBNull))
                    art.Categoria.Tipo = (string)lector["TIPO"];



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

        public void agregar(Articulo articuloNuevo) 
        {
            

        
        }

    }
}
