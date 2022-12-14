
using Biblioteca.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Biblioteca
{

    public delegate void DelegadoPrecio(object sender, EventArgs e);
    public delegate void DelegadoCambioLista(object sender, EventArgs e);

    public class Cartuchera<T> where T : Util
    {
        private int id_cartuchera;
        private int capacidad;
        private List<T> listaElementos;

        public static event DelegadoPrecio EventoPrecio;
        public event DelegadoCambioLista EventoCambioLista;

        #region CONSTRUCTORES
        public Cartuchera()
        {}

        public Cartuchera(int id_cartuchera, int capacidad) :this()
        {
            this.id_cartuchera = id_cartuchera;
            this.capacidad = capacidad;
            listaElementos = new List<T>();
        }
        #endregion

        #region PROPIEDADES
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
        #endregion

        private decimal CalcularPrecioTotal(List<T> lista)
        {
            decimal total = 0;
            foreach(T item in lista)
            {
                total += item.Precio;
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
                UtilesDAO.GuardarUtil(cartuchera.id_cartuchera, elemento);
                
            }
            if (Cartuchera<Util>.EventoPrecio is not null && cartuchera.PrecioTotal > 500)
            {
                Cartuchera<Util>.EventoPrecio.Invoke(CartucheraDAO.Leer(), new EventArgs());
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
