using Biblioteca;
using Interfaces;
using Persistencia;
using System;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // PRUEBAS DE CONSOLA
            //Lapiz lapiz1 = new Lapiz(1, "Lapiz", 100, EColorLapiz.Verde, true);
            //Console.WriteLine($"{lapiz1.Id}, {lapiz1.Nombre}, {lapiz1.Precio}, {lapiz1.Color}, {lapiz1.EsMecanico}");
            //
            Cartuchera<Util> cartuchera = CartucheraDAO.Leer();
            //foreach(Util item in CartucheraDAO.LeerLapices(cartuchera.Id_Cartuchera))
            //{
            //    cartuchera.ListaElementos.Add(item);
            //}
            //foreach (Util item in cartuchera.ListaElementos)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //Console.WriteLine($"Precio Total: {cartuchera.PrecioTotal}");

            try
            {
                //UtilesDAO.GuardarUtil(1, new Lapiz(0, "Prueba Util", 1000, EColorLapiz.Azul, true));
                //UtilesDAO.GuardarUtil(1, new Goma(0, "PruebaGoma", 1, false));
                //UtilesDAO.GuardarUtil(1, new Sacapunta(0, "PruebaSacapunta", 1, EMaterialSacapunta.Plastico));

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            cartuchera.EventoPrecio += (cartuchera, EventArgs) => Console.WriteLine("Ocurrio el evento.!!!!!!!!!!!!!!!!");

            //Console.WriteLine(cartuchera);

            //TicketManager.EscribirTicket(cartuchera);

            Lapiz lapiz = new Lapiz(1, "Faber", 100, EColorLapiz.Verde, true);
            ((ISerializa)lapiz).Xml();
            Console.ReadKey();

        }
    }
}
