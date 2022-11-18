
using System;
using System.Collections.Generic;
using System.Linq;
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
            get { return 0; }
        }

    }
}
