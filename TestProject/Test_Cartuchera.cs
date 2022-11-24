using Biblioteca;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace TestProject
{
    [TestClass]
    public class Test_Cartuchera
    {
        [TestMethod]
        public void PrecioTotal_CuandoLaCartucheraEstaVacia_DeberiaDevolverCero()
        {
            // Arrange
            Cartuchera<Util> cartuchera = new Cartuchera<Util>(0, 10);
            decimal esperado = 0;

            // Act
            decimal real = cartuchera.PrecioTotal;

            // Assert
            Assert.IsTrue(real == esperado);
        }

        [TestMethod]
        public void PrecioTotal_CuandoLaCartucheraValeCien_DeberiaDevolverCien()
        {
            // Arrange
            Cartuchera<Util> cartuchera = new Cartuchera<Util>(0, 10);
            Lapiz lapiz = new Lapiz(1, "", 50, EColorLapiz.Rojo, false);
            Goma goma = new Goma(1, "", 50, false);
            cartuchera.ListaElementos.Add(lapiz);
            cartuchera.ListaElementos.Add(goma);
            decimal esperado = 100;

            // Act
            decimal real = cartuchera.PrecioTotal;

            // Assert
            Assert.IsTrue(real == esperado);
        }


        [TestMethod]
        [ExpectedException(typeof(CartucheraLlenaException))]
        public void AgregarUtil_CuandoLaCartucheraEstaLlena_DeberiaDevolverCartucheraLlenaException()
        {
            // Arrange
            Cartuchera<Util> cartuchera = new Cartuchera<Util>(0, 0);
            Lapiz lapiz = new Lapiz(1, "", 50, EColorLapiz.Rojo, false);
            //Goma goma = new Goma(1, "", 50, false);
            //Act
            _ = cartuchera + lapiz;


        }


    }
}
