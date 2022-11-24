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

        /// <summary>
        /// Escribe en el ticket de la cartuchera en el archivo tickets.log en Mis Documentos
        /// </summary>
        /// <param name="cartuchera"></param>
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

        /// <summary>
        /// Escribe la accion en el archivo historial_de_acciones.log en Mis Documentos.
        /// </summary>
        /// <param name="nombreMetodoActual"></param>
        /// <param name="util"></param>
        public static void EscribirHistorialDeAcciones(string nombreMetodoActual, Util util)
        {
            StreamWriter sw = null;
            string rutaHistorial = Path.Combine(ruta, historialDeAcciones);

            try
            {
                sw = new StreamWriter(rutaHistorial, true);
                sw.WriteLine($"{DateTime.Now} ||\t\t {nombreMetodoActual} ||\t\t {util}");
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

        public static void EscribirErrores(int tintaFaltante, Util util)
        {
            StreamWriter sw = null;
            string rutaErrores = Path.Combine(ruta, "errores.log");

            try
            {
                sw = new StreamWriter(rutaErrores, true);
                sw.WriteLine($"{DateTime.Now} ||\t\t Tinta faltante: {tintaFaltante} ||\t\t Fibron: {util}");
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


    }
}
