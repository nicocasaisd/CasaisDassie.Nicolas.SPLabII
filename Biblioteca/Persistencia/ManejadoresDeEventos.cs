using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Persistencia
{
    public static class ManejadoresDeEventos
    {
        /// <summary>
        /// Manejador de EventoPrecio que escribe el ticket en el archivo tickets.log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void EventoPrecio_Handler(object sender, EventArgs e)
        {
            Cartuchera <Util> cartuchera = (Cartuchera<Util>)sender;
            TicketManager.EscribirTicket(cartuchera);
        }

        /// <summary>
        /// Manejador de EventoCambioLista que escribe en el historial de acciones lo que sucedió.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void EventoCambioLista_HistorialDeAccionesHandler(object sender, EventArgs e)
        {
            Util util = ((EventoCambioListaArgs)e).util;
            string nombreMetodoActual = ((EventoCambioListaArgs)e).nombreMetodoActual;

            TicketManager.EscribirHistorialDeAcciones(nombreMetodoActual, util);
        }

    }

    // Creo una herencia de la clase EventArgs
    public class EventoCambioListaArgs : EventArgs
    {
        public string nombreMetodoActual;
        public Util util;

        public EventoCambioListaArgs(string nombreMetodoActual) :base()
        {
            this.nombreMetodoActual = nombreMetodoActual;
        }

        public EventoCambioListaArgs(string nombreMetodoActual, Util util) : this(nombreMetodoActual)
        {
            this.util = util;
        }
    }


}
