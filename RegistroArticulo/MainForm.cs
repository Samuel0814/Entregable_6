using RegistroArticulo.UI.Consultas;
using RegistroArticulo.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroArticulo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void cotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cCotizaciones abrir = new cCotizaciones();
            abrir.Show();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rPersonas abrir = new rPersonas();
            abrir.Show();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rArticulos abrir = new rArticulos();
            abrir.Show();
        }

        private void articulosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cArticulos abrir = new cArticulos();
            abrir.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cPersonas abrir = new cPersonas();
            abrir.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir de la aplicacion?",
                       "Consulta",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true; //Cancela el cerrado del formulario
            }
        }
    }
}
