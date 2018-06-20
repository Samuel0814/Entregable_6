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
            bool paso;
            Articulos articulo = new Articulos();
            articulo.ArticuloID = 0;
            articulo.FechaVencimiento = Convert.ToDateTime(value: "05-12-2019");
            articulo.Descripcion = "Jugo Manzana";
            articulo.Existencia = 25;
            articulo.CantidadCotizada = 20;
            paso = BLL.ArticulosBLL.Guardar(articulo);
            Assert.AreEqual(paso, true);
            
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = BLL.ArticulosBLL.Eliminar(2);

            Assert.AreEqual(paso, true);
            
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Articulos articulo = new Articulos();
            articulo.ArticuloID = 5;
            articulo.Descripcion = "Jugo Manzana 300 Ml";
            articulo.Existencia = 30;
            articulo.CantidadCotizada = 20;
            paso = BLL.ArticulosBLL.Modificar(articulo);
            Assert.AreEqual(paso, true);
            
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