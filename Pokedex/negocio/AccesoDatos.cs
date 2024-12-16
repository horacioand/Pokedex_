using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    public class AccesoDatos
    {
        //propiedades necesarias para la conexion
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader reader;

        //acceso al lector
        public SqlDataReader Reader
        {
            get { return reader; }
        }
        //constructor clase. Instancia la conexión configurada y el comando.
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS01 ; database=POKEDEX_DB ; integrated security=true");
            comando = new SqlCommand();
        }
        //método setear consulta
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        //metodo ejecutar lectura
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                reader = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //metodo ejecutar acción contra la base de datos 
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
        //cerrar conexion a db
        public void cerrarConexion()
        {
            if (reader != null)
            {
                reader.Close();
            }
            conexion.Close();
        }
    }
}
