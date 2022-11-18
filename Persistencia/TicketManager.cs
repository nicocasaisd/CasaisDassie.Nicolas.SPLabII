using Biblioteca;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public static class TicketManager
    {
        static string archivo = "tickets.txt";
        static string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static string rutaCompleta = Path.Combine(ruta, archivo);

        public static void EscribirTicket(Cartuchera<Util> cartuchera)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(rutaCompleta, true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(cartuchera);
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

        public static string LeerTicket()
        {
            return "";
        }
    }
}
