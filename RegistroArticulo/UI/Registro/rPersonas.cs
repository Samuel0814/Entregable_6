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
    public partial class rPersonas : Form
    {
        public rPersonas()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(PersonaIdnumericUpDown.Value);
            Personas persona = BLL.PersonasBLL.Buscar(id);

            if (persona != null)
            {
                NombretextBox.Text = persona.Nombres;
                CedulamaskedTextBox.Text = persona.Cedula;
                DirecciontextBox.Text = persona.Direccion;
                TelefonomaskedTextBox.Text = persona.Telefono;
            }
            else
                MessageBox.Show("No se encontro!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void rPersonas_Load(object sender, EventArgs e)
        {

        }
        private bool Validar()
        {
            bool HayErrores = true;
            //todo: quitar los mensajes de los errores que ya no estan.

            //todo: Validar que el nombre no se duplique
            
            if (String.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                MyerrorProvider.SetError(NombretextBox, 
                    "No debes dejar este campo vacio");
                HayErrores = false;
            }
            if (String.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {
                MyerrorProvider.SetError(DirecciontextBox,
                    "No debe dejarlo el campo en vacio");
                HayErrores = false;
            }
            if (String.IsNullOrWhiteSpace(CedulamaskedTextBox.Text))
            {
                MyerrorProvider.SetError(CedulamaskedTextBox, 
                    "No debe dejar el campo en vacio");
                HayErrores = false;
            }
            if (String.IsNullOrWhiteSpace(TelefonomaskedTextBox.Text))
            {
                MyerrorProvider.SetError(TelefonomaskedTextBox,
                    "No debes dejar el nombre vacio");
                HayErrores = false;
            }
            //todo: validar demas campos
            return HayErrores;
        }

        private Personas LlenaClase()
        {
            Personas persona = new Personas();

            persona.PersonasId = Convert.ToInt32(PersonaIdnumericUpDown.Value);
            persona.Nombres = NombretextBox.Text;
            persona.Cedula = CedulamaskedTextBox.Text;
            persona.Direccion = DirecciontextBox.Text;
            persona.Telefono = TelefonomaskedTextBox.Text;

            return persona;
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(PersonaIdnumericUpDown.Value);

            //todo: validar que exista
            if (BLL.PersonasBLL.Eliminar(id))
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Personas persona;
            bool HayErrores = true;

            if (!Validar())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            persona = LlenaClase();

            //Determinar si es Guardar o Modificar
            if (PersonaIdnumericUpDown.Value == 0)
                HayErrores = BLL.PersonasBLL.Guardar(persona);
            else
                //todo: validar que exista.
                HayErrores = BLL.PersonasBLL.Modificar(persona);

            //Informar el resultado
            if (HayErrores)
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            PersonaIdnumericUpDown.Value = 0;
            NombretextBox.Clear();
            CedulamaskedTextBox.Clear();
            DirecciontextBox.Clear();
            TelefonomaskedTextBox.Clear();
            MyerrorProvider.Clear();
        }
    }
}
