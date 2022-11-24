using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Persistencia
{
    public static class TicketManager
    {
        static string archivo = "tickets.log";
        static string historialDeAcciones = "historial_de_acciones.log";
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
                if (sw is not null)
                {
                    sw.Close();
                }
            }
        }

        public static void EscribirHistorialDeAcciones(Action<object, EventArgs> accion, Util util)
        {
            StreamWriter sw = null;
            string rutaHistorial = Path.Combine(ruta, historialDeAcciones);

            try
            {
                sw = new StreamWriter(rutaHistorial, true);
                sw.WriteLine($"{DateTime.Now} ||\t\t {accion.Method.Name} ||\t\t {util}");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sw is not null)
                {
                    sw.Close();
                }
            }
        }

        public static string LeerTicket()
        {
            string ticket = String.Empty;
            try
            {

                using (StreamReader reader = new StreamReader(rutaCompleta))
                {
                    ticket = reader.ReadToEnd();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return ticket;
        }
    }
}
