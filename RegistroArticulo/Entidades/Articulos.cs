using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroArticulo.Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticuloID { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public int CantidadCotizada { get; set; }

        public Articulos(int articuloID, DateTime FechaVencimiento, string descripcion, decimal precio, int Existencia, int CantidadCotizada)
        {
            this.ArticuloID = articuloID;
            this.FechaVencimiento = FechaVencimiento;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Existencia = Existencia;
            this.CantidadCotizada = CantidadCotizada;
        }

        public Articulos()
        {
            this.ArticuloID = 0;
            this.FechaVencimiento = DateTime.Now;
            this.Descripcion = string.Empty;
            this.Precio = 0;
            this.Existencia = 0;
            this.CantidadCotizada = 0;
        }
    }
}
