using RegistroArticulo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace RegistroArticulo.UI.Consultas
{
    public partial class cPersonas : Form
    {
        public cPersonas()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            //Inicializando el filtro en True
            Expression<Func<Personas, bool>> filtro = x => true;

            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://ID
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.PersonasId == id
                    && (DesdedateTimePicker.Value <= HastadateTimePicker.Value);
                    break;
                case 1:// nombre
                    filtro = x => x.Nombres.Contains(CriteriotextBox.Text)
                    && (DesdedateTimePicker.Value <= HastadateTimePicker.Value);
                    break;
                case 2:// cedula
                    filtro = x => x.Cedula.Equals(CriteriotextBox.Text)
                    && (DesdedateTimePicker.Value <= HastadateTimePicker.Value);
                    break;
                case 3:// direccion
                    filtro = x => x.Direccion.Contains(CriteriotextBox.Text)
                    && (DesdedateTimePicker.Value <= HastadateTimePicker.Value);
                    break;
                case 4://telefono
                    filtro = x => x.Telefono.Equals(CriteriotextBox.Text)
                    && (DesdedateTimePicker.Value <= HastadateTimePicker.Value);
                    break;
            }


            ConsultadataGridView.DataSource = BLL.PersonasBLL.GetList(filtro);
        }
    }
}
