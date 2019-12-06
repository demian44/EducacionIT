using Clase6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Test01
{
    [TestClass]
    public class TestClase6
    {
        [TestMethod]
        public void TestMethod1()
        {
            string strValorEsperado = "Hola Mundo";
            var swPrueba = new StringWriter();
            Console.SetOut(swPrueba);
            Program.Main(null);
            var resultado = swPrueba.ToString().Trim();
            Assert.AreEqual(strValorEsperado, resultado);
        }
    }
}
