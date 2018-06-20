using RegistroArticulo.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace RegistroArticulo.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulos> articulo { get; set; }
        public DbSet<Cotizaciones> Cotizar { get; set; }
        public DbSet<CotizacionesDetalle> Detalle { get; set; }

        public Contexto() : base("ConStr")
        {
        }
    }
}
