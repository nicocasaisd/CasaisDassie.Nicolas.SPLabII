using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Persistencia
{
    public static class ManejadoresDeEventos
    {
        public static void EventoPrecio_Handler(object sender, EventArgs e)
        {
            Cartuchera <Util> cartuchera = (Cartuchera<Util>)sender;
            TicketManager.EscribirTicket(cartuchera);
        }

        public static void EventoCambioLista_HistorialDeAccionesHandler(object sender, EventArgs e)
        {
            //Action<object, EventArgs> accion = ((EventoCambioListaArgs)e).accion;
            Util util = ((EventoCambioListaArgs)e).util;
            string nombreMetodoActual = ((EventoCambioListaArgs)e).nombreMetodoActual;

            //Action<Action<object, EventArgs>, Util> delegado;
            //delegado = TicketManager.EscribirHistorialDeAcciones;
            //Task hilo = new Task();
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
