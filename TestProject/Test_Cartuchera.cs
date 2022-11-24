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

            // Act
            decimal precio = cartuchera.PrecioTotal;

            // Assert
            Assert.IsTrue(precio == 0);
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
