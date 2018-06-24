using RegistroArticulo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroArticulo.UI.Registro
{
    public partial class rArticulos : Form
    {
        public rArticulos()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var articulo = BLL.ArticulosBLL.Buscar(Convert.ToInt32(ArticuloIdnumericUpDown.Value));
            if (articulo != null)
            {
                PrecionumericUpDown.Value = articulo.Precio;
                DescripciontextBox.Text = articulo.Descripcion;
                CantidadCotizzadanumericUpDown.Text = articulo.CantidadCotizada.ToString();
            }
            else
            {
                MessageBox.Show("No encontrado");
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            ArticuloIdnumericUpDown.Value = 0;
            PrecionumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            CantidadCotizzadanumericUpDown.Value = 0;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Articulos articulo = LlenaClase();
            if (ArticuloIdnumericUpDown.Value == 0)
            {
                if (BLL.ArticulosBLL.Guardar(articulo))
                {
                    MessageBox.Show("Guardado");
                }
            }
            else
            {
                if (BLL.ArticulosBLL.Modificar(LlenaClase()))
                {
                    MessageBox.Show("Modificado");
                }
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if(BLL.ArticulosBLL.Eliminar(Convert.ToInt32(ArticuloIdnumericUpDown.Value)))
            {
                MessageBox.Show("Eliminado");
            }
        }

        private Articulos LlenaClase()
        {
            Articulos articulo = new Articulos();


            articulo.Descripcion = DescripciontextBox.Text;
            articulo.Precio = PrecionumericUpDown.Value;

            return articulo;
        }

        private bool Validar()
        {
            bool HayErrores = false;
            //todo: quitar los mensajes de los errores que ya no estan.

            //todo: Validar que el nombre no se duplique
            if (String.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                MyerrorProvider.SetError(DescripciontextBox,
                    "No debes dejar el nombre vacio");
                HayErrores = true;
            }

            //todo: validar demas campos
            return HayErrores;
        }

        private void rArticulos_Load(object sender, EventArgs e)
        {

        }
    }
}
