
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{

    public delegate void DelegadoPrecio(object sender, EventArgs e);

    public class Cartuchera<T> where T : Util
    {
        private int id_cartuchera;
        private int capacidad;
        private List<T> listaElementos;

        public event DelegadoPrecio EventoPrecio;

        public Cartuchera(int id_cartuchera, int capacidad)
        {
            this.id_cartuchera = id_cartuchera;
            this.capacidad = capacidad;
            listaElementos = new List<T>();
        }

        public decimal PrecioTotal
        {
            get { return CalcularPrecioTotal(listaElementos); }
        }

        private decimal CalcularPrecioTotal(List<T> lista)
        {
            decimal total = 0;
            foreach(T item in lista)
            {
                total += item.Precio * item.Cantidad;
            }
            // Evento precio
            if(EventoPrecio is not null && total >= 500)
            {
                EventoPrecio.Invoke(this, new EventArgs());
            }
            return total;
        }

        public static bool operator +(Cartuchera<T> cartuchera, T elemento)
        {
            if(cartuchera.listaElementos.Count == cartuchera.capacidad)
            {
                throw new CartucheraLlenaException("La cartuchera está llena.");
            }
            else
            {
                cartuchera.listaElementos.Add(elemento);
            }
            return false;
        }

    }

    
}
