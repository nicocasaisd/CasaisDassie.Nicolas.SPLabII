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
            Action<object, EventArgs> accion = ((EventoCambioListaArgs)e).accion;
            Util util = ((EventoCambioListaArgs)e).util;

            Action<Action<object, EventArgs>, Util> delegado;
            delegado = TicketManager.EscribirHistorialDeAcciones;
            //Task hilo = new Task();
            TicketManager.EscribirHistorialDeAcciones(accion, util);
        }

    }

    // Creo una herencia de la clase EventArgs
    public class EventoCambioListaArgs : EventArgs
    {
        public Action<object, EventArgs> accion;
        public Util util;

        public EventoCambioListaArgs(Action<object, EventArgs> accion) :base()
        {
            this.accion = accion;
        }

        public EventoCambioListaArgs(Action<object, EventArgs> accion, Util util) : this(accion)
        {
            this.util = util;
        }
    }


}
