using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace RegistroArticulo.Entidades
{
    public class CotizacionesDetalle
    {
        [Key]
        public int ID { get; set; }
        public int CotizacionesID { get; set; }
        public int ArticuloID { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        //https://www.tektutorialshub.com/data-annotations-notmapped-attribute-in-entity-framework/
        //se aplica a esas propiedades, que no desea incluir en su tabla de base de datos. Este atributo
        //generalmente se usa en el caso de campos calculados como edad, cantidad, etc.

        [NotMapped]
        public string Descripcion { get; set; }
        [NotMapped]
        public int Importe { get; set; }

        public CotizacionesDetalle(int cotizacionesID, int articuloID, int cantidad, decimal precio, string descripcion, int importe)
        {

            this.CotizacionesID = cotizacionesID;
            this.ArticuloID = articuloID;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Descripcion = descripcion;
            this.Importe = importe;
        }


        public CotizacionesDetalle()
        {

            this.CotizacionesID = 0;
            this.ArticuloID = 0;
            this.Cantidad = 0;
            this.Precio = 0;
        }
    }
}
