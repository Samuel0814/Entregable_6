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
    public class ArticulosBLL
    {
        public static bool Guardar(Articulos articulo)
        {
            bool paso = false;
            Contexto contex = new Contexto();
            try
            {
                if (contex.articulo.Add(articulo) != null)
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contex = new Contexto();
            try
            {
                var eliminar = contex.articulo.Find(id);
                contex.Entry(eliminar).State = EntityState.Deleted;
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

        public static bool Modificar(Articulos articulo)
        {
            bool paso = false;
            Contexto contex = new Contexto();
            try
            {
                contex.Entry(articulo).State = EntityState.Modified;
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

        public static Articulos Buscar(int id)
        {

            Contexto contex = new Contexto();
            Articulos articulo = new Articulos();
            try
            {
                articulo = contex.articulo.Find(id);

            }
            catch (Exception)
            {

                throw;
            }
            return articulo;
        }

        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> articulo)
        {
            List<Articulos> articulos = new List<Articulos>();
            Contexto contex = new Contexto();

            try
            {
                articulos = contex.articulo.Where(articulo).ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return articulos;
        }
    }
}
