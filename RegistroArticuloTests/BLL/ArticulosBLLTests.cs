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
    public class ArticulosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool HayErrores;
            Articulos articulo = new Articulos();
            articulo.ArticuloID = 10;
            articulo.Descripcion = "Que tal";
            articulo.Fecha = DateTime.Now;
            articulo.Precio = 30;
            articulo.Existencia = 6;
            articulo.CantidadCotizada = 8;
            HayErrores = BLL.ArticulosBLL.Guardar(articulo);
            Assert.AreEqual(HayErrores, true);

        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool HayErrores;
            HayErrores = BLL.ArticulosBLL.Eliminar(2);

            Assert.AreEqual(HayErrores, true);
            
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool HayErrores;
            Articulos articulo = new Articulos();
            articulo.ArticuloID = 5;
            articulo.Descripcion = "Jugo Manzana 300 Ml";
            articulo.Existencia = 30;
            articulo.CantidadCotizada = 20;
            HayErrores = BLL.ArticulosBLL.Modificar(articulo);
            Assert.AreEqual(HayErrores, true);
            
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Articulos articulo = new Articulos();

            articulo = BLL.ArticulosBLL.Buscar(3);
            Assert.IsNotNull(articulo);

        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = BLL.ArticulosBLL.GetList(x => true);

            Assert.IsNotNull(lista);
            
        }
    }
}