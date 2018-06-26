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
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Existencia { get; set; }
        public int CantidadCotizada { get; set; }

        public Articulos(int articuloID, DateTime Fecha, string descripcion, int precio, int Existencia, int CantidadCotizada)
        {
            this.ArticuloID = articuloID;
            this.Fecha = Fecha;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Existencia = Existencia;
            this.CantidadCotizada = CantidadCotizada;
        }

        public Articulos()
        {
            this.ArticuloID = 0;
            this.Fecha = DateTime.Now;
            this.Descripcion = string.Empty;
            this.Precio = 0;
            this.Existencia = 0;
            this.CantidadCotizada = 0;
        }
    }
}
