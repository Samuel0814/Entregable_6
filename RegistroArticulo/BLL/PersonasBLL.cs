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
    public class PersonasBLL
    {
        public static bool Guardar(Personas personas)
        {
            bool paso = false;
            
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Personas.Add(personas)!= null)
                {
                    contexto.SaveChanges(); 
                    paso = true;
                }

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static bool Modificar(Personas personas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(personas).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int PersonasId)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Personas personas = contexto.Personas.Find(PersonasId);

                contexto.Personas.Remove(personas);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static Personas Buscar(int PersonasId)
        {
            Contexto contexto = new Contexto();
            Personas personas = new Personas();
            try
            {
                personas = contexto.Personas.Find(PersonasId);
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return personas;
        }

        public static List<Personas> GetList(Expression<Func<Personas, bool>> expression)
        {
            List<Personas> personas = new List<Personas>();
            Contexto contexto = new Contexto();
            try
            {
                personas = contexto.Personas.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return personas;
        }
    }
}