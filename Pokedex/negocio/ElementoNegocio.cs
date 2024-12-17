using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class ElementoNegocio
    {
        public List<Elemento> listar()
        {
            List<Elemento> listaElementos = new List<Elemento>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM Elementos");
                datos.ejecutarLectura();
                while (datos.Reader.Read())
                {
                    Elemento auxiliar = new Elemento();
                    auxiliar.Id = (int)datos.Reader["Id"];
                    auxiliar.Descripcion = (string)datos.Reader["Descripcion"];
                    listaElementos.Add(auxiliar);
                }
                return listaElementos;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
