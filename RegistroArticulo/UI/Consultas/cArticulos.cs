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
    public partial class cArticulos : Form
    {
        public cArticulos()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            //Inicializando el filtro en True
            Expression<Func<Articulos, bool>> filtro = x => true;

            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://ID
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.ArticuloID == id
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 1:// Descripcion
                    filtro = x => x.Descripcion.Contains(CriteriotextBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 2:// Precio
                    filtro = x => x.Precio.Equals(CriteriotextBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 3:// Existencia
                    filtro = x => x.Existencia.Equals(CriteriotextBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 4://CantidadCotizada
                    filtro = x => x.CantidadCotizada.Equals(CriteriotextBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
            }


            ConsultadataGridView.DataSource = BLL.ArticulosBLL.GetList(filtro);
        }

        private void cArticulos_Load(object sender, EventArgs e)
        {

        }
    }
}
