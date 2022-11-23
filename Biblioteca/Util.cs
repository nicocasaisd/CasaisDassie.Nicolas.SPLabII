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
        private string marca;
        private decimal precio;

        public Util()
        {}
        protected Util(int id, string marca, decimal precio) :this()
        {
            this.id = id;
            this.marca = marca;
            this.precio = precio;
        }

        public int Id 
        { 
            get { return id; } 
            set { id = value; }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public decimal Precio 
        { 
            get { return precio; } 
            set { precio = value; }
        }

        public ETipoDeUtil Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }


    }
}
