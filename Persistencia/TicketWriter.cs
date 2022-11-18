using Biblioteca;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public static class TicketWriter
    {
        static string archivo = "tickets.txt";

        public static void EscribirTicket(Cartuchera<Util> cartuchera)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(archivo, true);
                sw.WriteLine("Prueba");

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if(sw is not null)
                {
                    sw.Close();
                }
            }
        }
    }
}
