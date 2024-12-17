using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> listaPokemon = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Numero, Nombre, P.Descripcion, UrlImagen, T.Descripcion AS Tipo, D.Descripcion AS Debilidad FROM POKEMONS P, ELEMENTOS T, ELEMENTOS D WHERE P.IdTipo = T.Id AND P.IdDebilidad = D.Id");
                datos.ejecutarLectura();
                while (datos.Reader.Read())
                {
                    Pokemon auxiliar = new Pokemon();
                    auxiliar.Numero = (int)datos.Reader["Numero"];
                    auxiliar.Nombre = (string)datos.Reader["Nombre"];
                    auxiliar.Descripcion = (string)datos.Reader["Descripcion"];
                    auxiliar.Imagen = (string)datos.Reader["UrlImagen"];
                    auxiliar.Tipo = new Elemento();
                    auxiliar.Tipo.Descripcion = (string)datos.Reader["Tipo"];
                    auxiliar.Debilidad = new Elemento();
                    auxiliar.Debilidad.Descripcion = (string)datos.Reader["Debilidad"];
                    listaPokemon.Add(auxiliar);

                }
                return listaPokemon;
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
        public void agregarPokemon(Pokemon pokemon)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO POKEMONS (Numero, Nombre, Descripcion, Activo) VALUES ("+ pokemon.Numero +",'"+ pokemon.Nombre +"','"+ pokemon.Descripcion +"',1)");
                datos.ejecutarAccion();
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
 