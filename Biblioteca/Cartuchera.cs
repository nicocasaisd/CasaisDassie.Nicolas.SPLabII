
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Cartuchera<T> where T : Util
    {

        private int capacidad;
        private List<T> listaElementos;

        public Cartuchera(int capacidad)
        {
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
            return total;
        }

        public static bool operator +(Cartuchera<T> cartuchera, T elemento)
        {
            
            return false;
        }

    }
}
