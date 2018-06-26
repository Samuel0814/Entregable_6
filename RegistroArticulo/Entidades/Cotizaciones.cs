using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroArticulo.Entidades
{
    public class Cotizaciones
    {
        [Key]
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public int Monto { get; set; }

        public virtual List<CotizacionesDetalle> CotizacionDetalle { get; set; }

        public Cotizaciones(DateTime fecha, string comentario, int monto, List<CotizacionesDetalle> Cotizaciondetalle)
        {
            this.Fecha = fecha;
            this.Comentario = comentario;
            this.Monto = monto;
            this.CotizacionDetalle = Cotizaciondetalle;
        }

        public Cotizaciones()
        {
            this.ID = 0;
            this.Fecha = DateTime.Now;
            this.Comentario = string.Empty;
            this.Monto = 0;
            this.CotizacionDetalle = new List<CotizacionesDetalle>();
        }
    }
}
