using RegistroArticulo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroArticulo.UI.Consultas
{
    public partial class cCotizaciones : Form
    {
        Cotizaciones cotisar = new Cotizaciones();
        public cCotizaciones()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var cotizacion = BLL.CotizacionBLL.Buscar(Convert.ToInt32(IDnumericUpDown.Value));
            ComentariotextBox.Text = cotizacion.Comentario;
            MontotextBox.Text = cotizacion.Monto.ToString();
            FechadateTimePicker.Value = cotizacion.Fecha;
            DetalledataGridView.DataSource = cotizacion.CotizacionDetalle;
        }

        private void BuscarArticulobutton_Click(object sender, EventArgs e)
        {
            var articulo = BLL.ArticulosBLL.Buscar(Convert.ToInt32(ArticuloIdnumericUpDown.Value));
            if (articulo != null)
            {
                DescripciontextBox.Text = articulo.Descripcion;
                PreciotextBox.Text = articulo.Precio.ToString();
            }
            else
            {
                MessageBox.Show("No se encuentra");
            }
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            DetalledataGridView.DataSource = null;
            var articulo = BLL.ArticulosBLL.Buscar(Convert.ToInt32(ArticuloIdnumericUpDown.Value));

            cotisar.CotizacionDetalle.Add(new CotizacionesDetalle(cotisar.ID, articulo.ArticuloID, Convert.ToInt32(CantidadnumericUpDown.Value), articulo.Precio, DescripciontextBox.Text, Convert.ToInt32(ImportetextBox.Text)));
            DetalledataGridView.DataSource = cotisar.CotizacionDetalle;
            MontotextBox.Text = cotisar.Monto.ToString();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            CantidadnumericUpDown.Value = 0;
            ComentariotextBox.Clear();
            IDnumericUpDown.Value = 0;
            MontotextBox.Clear();
            DetalledataGridView.DataSource = null;
            FechadateTimePicker.Value = DateTime.Now;
            cotisar = new Cotizaciones();
            DescripciontextBox.Clear();
            PreciotextBox.Clear();
            ArticuloIdnumericUpDown.Value = 0;
            ImportetextBox.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Cotizaciones cotisar = LlenaClase();

            if (IDnumericUpDown.Value == 0)
            {
                if (BLL.CotizacionBLL.Guardar(cotisar))
                {
                    MessageBox.Show("Guardado");
                }
            }
            else
            {
                if (BLL.CotizacionBLL.Modificar(LlenaClase()))
                {
                    MessageBox.Show("Modificado");
                }
            }
        }

        private void cCotizaciones_Load(object sender, EventArgs e)
        {

        }

        private Cotizaciones LlenaClase()
        {

            cotisar.Comentario = ComentariotextBox.Text;
            cotisar.Monto += BLL.CotizacionBLL.calcularMonto(Convert.ToDecimal(PreciotextBox.Text), CantidadnumericUpDown.Value);
            cotisar.Fecha = FechadateTimePicker.Value;
            return cotisar;
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (BLL.CotizacionBLL.Eliminar(Convert.ToInt32(IDnumericUpDown.Value)))
            {
                MessageBox.Show("Eliminado");
            }
        }

        private void CantidadnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ImportetextBox.Text = BLL.CotizacionBLL.calcularMonto(Convert.ToDecimal(PreciotextBox.Text), CantidadnumericUpDown.Value).ToString();
        }

        private void ArticuloIdnumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BuscarArticulobutton_Click_1(object sender, EventArgs e)
        {
            var articulo = BLL.ArticulosBLL.Buscar(Convert.ToInt32(ArticuloIdnumericUpDown.Value));
            if (articulo != null)
            {
                DescripciontextBox.Text = articulo.Descripcion;
                PreciotextBox.Text = articulo.Precio.ToString();
            }
            else
            {
                MessageBox.Show("No se encuentra");
            }
        }

        private void Consultabutton_Click(object sender, EventArgs e)
        {

        }

        private void MontotextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Buscarbutton_Click_1(object sender, EventArgs e)
        {
            var cotizacion = BLL.CotizacionBLL.Buscar(Convert.ToInt32(IDnumericUpDown.Value));
            ComentariotextBox.Text = cotizacion.Comentario;
            MontotextBox.Text = cotizacion.Monto.ToString();
            FechadateTimePicker.Value = cotizacion.Fecha;
            DetalledataGridView.DataSource = cotizacion.CotizacionDetalle;
        }
    }
}
