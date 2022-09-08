using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class AccesoDatos
    {
        /*
                private SqlConnection conexion;
                private SqlCommand comando;
                private SqlDataReader lector;
                public SqlDataReader Lector
                {
                    get { return lector; }
                }

                public AccesoDatos()
                {
                    conexion = new SqlConnection("server=.//SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
                    comando = new SqlCommand();
                }

                public void setearConsulta(string consulta)
                {
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = consulta;
                }

                public void ejecutarLectura()
                {
                    comando.Connection = conexion;
                    try
                    {
                        conexion.Open();
                        lector = comando.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                public void ejecutarAccion()
                {
                    comando.Connection = conexion;
                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                public void setearParametro(string nombre, object valor)
                {
                    comando.Parameters.AddWithValue(nombre, valor);
                }

                public void cerrarConexion()
                {
                    if (lector != null)
                        lector.Close();
                    conexion.Close();
                }

            */
        public List<Articulo> Listar()
        {
 
        List<Articulo> lista = new List<Articulo>();

         SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
      
            try
            {
                conexion = new SqlConnection("server=.//SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            comando = new SqlCommand();
            comando.CommandText = "Select  Id, Codigo, Nombre, Descripcion From ARTICULOS";
            comando.Connection = conexion;

            conexion.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
               {
                Articulo aux = new Articulo();
                aux.Id = lector.GetInt32(0);
                aux.Codigo = lector.GetString(1);
                aux.Nombre = lector.GetString(2); /// (string) lector.["Nombre"];
                    aux.Descripcion = lector.GetString(3);

                lista.Add(aux); 


               }

            conexion.Close();

                return lista;

            }

             catch (Exception ex)
            {
                throw ex;
            }

            /// AccesoDatos.conexion();
            /// AccesoDatos.setearConsulta(string consulta);
            /// AccesoDatos.ejecutarLectura();


        }

    }
}
