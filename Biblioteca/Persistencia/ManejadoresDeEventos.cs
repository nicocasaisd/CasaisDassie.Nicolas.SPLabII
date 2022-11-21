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

    }
}
