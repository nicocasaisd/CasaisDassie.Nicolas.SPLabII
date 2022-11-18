using System;

namespace Biblioteca
{
    public enum ETipoDeUtil
    {
        Lapiz=1, Goma=2, Sacapunta=3
    }

    public abstract class Util
    {
        private int id;
        protected ETipoDeUtil tipo;
        private string nombre;
        private decimal precio;

        protected Util(int id, string nombre, decimal precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
        }

        public int Id { get { return id; } }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public decimal Precio 
        { 
            get { return precio; } 
            set { precio = value; }
        }


    }
}
