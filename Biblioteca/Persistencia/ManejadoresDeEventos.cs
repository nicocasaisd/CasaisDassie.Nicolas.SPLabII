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
            TicketManager.EscribirHistorialDeAcciones(((EventoCambioListaArgs)e).accion, ((EventoCambioListaArgs)e).util);
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
