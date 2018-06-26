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
            Articulos articulo;
            bool HayErrores = true;

            if (!Validar())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            articulo = LlenaClase();

            //Determinar si es Guardar o Modificar
            if (ArticuloIdnumericUpDown.Value == 0)
                HayErrores = BLL.ArticulosBLL.Guardar(articulo);
            else
                //todo: validar que exista.
                HayErrores = BLL.ArticulosBLL.Modificar(articulo);

            //Informar el resultado
            if (HayErrores)
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            articulo.Precio = Convert.ToInt32(PrecionumericUpDown.Value);

            return articulo;
        }

        private bool Validar()
        {
            bool HayErrores = true;
            //todo: quitar los mensajes de los errores que ya no estan.

            //todo: Validar que el nombre no se duplique
            if (String.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                MyerrorProvider.SetError(DescripciontextBox,
                    "No debes dejar este campo vacio");
                HayErrores = false;
            }
            if (PrecionumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(PrecionumericUpDown, "No debe dejarlo el campo en 0");
                HayErrores = false;
            }
            if (ExistencianumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(ExistencianumericUpDown, "No debe dejarlo el campo en 0");
                HayErrores = false;
            }
            if (CantidadCotizzadanumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(CantidadCotizzadanumericUpDown, "No debe dejarlo el campo en 0");
                HayErrores = false;
            }
            //todo: validar demas campos
            return HayErrores;
        }

        private void rArticulos_Load(object sender, EventArgs e)
        {

        }

        private void FechadateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PrecionumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PrecionumericUpDown_ValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}
