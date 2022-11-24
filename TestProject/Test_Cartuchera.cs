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
            Cartuchera<Util> cartuchera = new Cartuchera<Util>(1, 10);
            decimal esperado = 0;

            // Act
            decimal real = cartuchera.PrecioTotal;

            // Assert
            Assert.IsTrue(real == esperado);
        }


        //[TestMethod]
        //[ExpectedException(typeof(InvalidCastException))]
        //public void SerializarXml_CuandoElArgumentoNoEsLapiz_DeberiaDevolverInvalidCastException()
        //{
        //    // Arrange

        //    //Act

            
        //}


    }
}
