using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;
namespace Visual
{
    public partial class frmAgregar : Form
    {
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();
            List<Elemento> listaElementos = elementoNegocio.listar();
            cboTipo.DataSource = listaElementos;
            cboDebilidad.DataSource = listaElementos;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PokemonNegocio pokemonNegocio = new PokemonNegocio();
            Pokemon nuevoPokemon = new Pokemon();
            nuevoPokemon.Numero = int.Parse(txtNumero.Text);
            nuevoPokemon.Nombre = txtNombre.Text;
            nuevoPokemon.Descripcion = txtDescripcion.Text;
            pokemonNegocio.agregarPokemon(nuevoPokemon);
            Close();
        }
    }
}
