using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroArticulo.BLL;
using RegistroArticulo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistroArticulo.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool HayErrores;
            Personas personas = new Personas();
            personas.PersonasId = 10;
            personas.Fecha = DateTime.Now;
            personas.Nombres = "Que tal";
            personas.Cedula = "40226240459";
            personas.Telefono = "8092404143";
            personas.Direccion = "La mata";
            HayErrores = BLL.PersonasBLL.Guardar(personas);
            Assert.AreEqual(HayErrores, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool HayErrores;
            Personas personas = new Personas();
            personas.PersonasId = 10;
            personas.Fecha = DateTime.Now;
            personas.Nombres = "xd tal";
            personas.Cedula = "11111111111";
            personas.Telefono = "1111111111";
            personas.Direccion = "La cueva";
            HayErrores = BLL.PersonasBLL.Modificar(personas);
            Assert.AreEqual(HayErrores, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool HayErrores = false;
            HayErrores = PersonasBLL.Eliminar(5);
            Assert.AreEqual(HayErrores, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Personas personas = new Personas();
            personas = PersonasBLL.Buscar(5);
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = PersonasBLL.GetList(x => true);
            Assert.IsNotNull(lista);
        }
    }
}