using System;

namespace Biblioteca
{
    public abstract class Util
    {
        private int id;
        private decimal precio;
        private int cantidad;

        public int Id { get { return id; } }
        public decimal Precio 
        { 
            get { return precio; } 
            set { precio = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
    }
}
