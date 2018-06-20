using RegistroArticulo.DAL;
using RegistroArticulo.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroArticulo.BLL
{
    public class CotizacionBLL
    {
        static int IDs = 0;
        public static bool Guardar(Cotizaciones cotizacion)
        {
            bool paso = false;
            try
            {
                Contexto contex = new Contexto();
                if (contex.Cotizar.Add(cotizacion) != null)
                {
                    contex.SaveChanges();
                    paso = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }
        private static void BuscarID(Cotizaciones cotizaciones)
        {
            IDs = cotizaciones.ID;

        }
        public static int RetornarID()
        {
            return IDs;
        }
        public static int calcularMonto(decimal cantidad, decimal precio)
        {
            int resultado;
            resultado = Convert.ToInt32(cantidad) * Convert.ToInt32(precio);

            return resultado;
        }


        public static bool Eliminar(int ID)
        {
            bool paso = false;
            try
            {
                Contexto contex = new Contexto();
                var cotizaciones = contex.Cotizar.Find(ID);
                contex.Detalle.RemoveRange(contex.Detalle.Where(x => x.CotizacionesID == cotizaciones.ID));
                contex.Entry(cotizaciones).State = System.Data.Entity.EntityState.Deleted;
                if (contex.SaveChanges() > 0)
                {

                    paso = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static bool Modificar(Cotizaciones cotizaciones)
        {
            bool paso = false;

            try
            {
                Contexto contex = new Contexto();
                contex.Entry(cotizaciones).State = System.Data.Entity.EntityState.Modified;
                if (contex.SaveChanges() > 0)
                {
                    paso = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }
        public static int CotisarMonto(List<CotizacionesDetalle> detalle)
        {
            int monto = 0;
            foreach (var cotisar in detalle)
            {
                monto += (Convert.ToInt32(cotisar.Precio) * cotisar.Cantidad);
            }

            return monto;
        }
        public static Cotizaciones Buscar(int ID)
        {
            Cotizaciones cotizaciones = new Cotizaciones();
            try
            {
                Contexto contex = new Contexto();
                cotizaciones = contex.Cotizar.Find(ID);

            }
            catch (Exception)
            {

                throw;
            }
            return cotizaciones;
        }

        public static List<Cotizaciones> GetList(Expression<Func<Cotizaciones, bool>> cotizacione)
        {
            List<Cotizaciones> cotizaciones = new List<Cotizaciones>();
            try
            {

                Contexto contex = new Contexto();
                cotizaciones = contex.Cotizar.Where(cotizacione).ToList();

            }
            catch (Exception)
            {

                throw;
            }
            return cotizaciones;
        }
    }
}
