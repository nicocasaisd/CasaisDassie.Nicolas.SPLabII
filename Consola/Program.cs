using Biblioteca;
using Persistencia;
using System;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // PRUEBAS DE CONSOLA
            //Lapiz lapiz1 = new Lapiz(1, "Lapiz", 100, ColorLapiz.Verde, true);
            //Console.WriteLine($"{lapiz1.Id}, {lapiz1.Nombre}, {lapiz1.Precio}, {lapiz1.Color}, {lapiz1.EsMecanico}");
            //
            Cartuchera<Util> cartuchera = CartucheraDAO.Leer();
            Console.WriteLine("...");
        
        }
    }
}
