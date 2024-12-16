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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

       
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //abrir ventana agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar frmAgregar = new frmAgregar();
            frmAgregar.ShowDialog();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            PokemonNegocio pokemonNegocio = new PokemonNegocio();
            List<Pokemon> listaPokemon = pokemonNegocio.listar();
            dgvPokemons.DataSource = listaPokemon;

            dgvPokemons.Columns[3].Visible = false;  //Ocultar columna imagen
        }
        private void dgvPokemons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            actualizarImagen(seleccionado.Imagen);
            actualizarNombre(seleccionado.Nombre);
        }




        private void actualizarImagen(string imagen)
        {
            try
            {
                pboPokemon.Load(imagen);
            }
            catch (Exception)
            {
                pboPokemon.Load("https://weightlosstransform.com/wp-content/uploads/2020/10/WhatsApp-Image-2020-08-17-at-23.57.51-2.jpeg");
            }
        }
        private void actualizarNombre(string nombre)
        {
            try
            {
                lblNombreActivo.Text = nombre;
            }
            catch (Exception)
            {
                lblNombreActivo.Text = "Desconocido";
            }
        }

        
    }
}
