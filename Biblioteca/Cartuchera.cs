
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

        public Cartuchera()
        {}

        public Cartuchera(int id_cartuchera, int capacidad) :this()
        {
            this.id_cartuchera = id_cartuchera;
            this.capacidad = capacidad;
            listaElementos = new List<T>();
        }

        public int Id_Cartuchera
        {
            get { return this.id_cartuchera; }
        }

        public List<T> ListaElementos
        {
            get { return this.listaElementos; }
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
                total += item.Precio;
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
                //UtilesDAO.GuardarUtil(cartuchera.id_cartuchera, elemento);
                cartuchera.listaElementos.Add(elemento);
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("------------------------------------------");
            foreach(Util item in ListaElementos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine($"      *** Precio Total: ${PrecioTotal:#.00} ***");
            sb.AppendLine("------------------------------------------");

            return sb.ToString();
        }

    }

    
}
