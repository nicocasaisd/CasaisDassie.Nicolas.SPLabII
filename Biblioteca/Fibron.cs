using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Fibron : Util
    {
		private int tinta;
		private EColorLapiz color;

		public Fibron(int id, string marca, decimal precio, int tinta, EColorLapiz color) :base(id, marca, precio)

        {
			this.tinta = tinta;
			this.color = color;
		}

		public EColorLapiz Color
		{
			get { return color; }
			set { color = value; }
		}


		public int Tinta
		{
			get { return tinta; }
			set { tinta = value; }
		}


		public int Resaltar(int cantidad)
		{
			if(tinta >= cantidad)
			{

				this.tinta -= cantidad;
			}
			else
			{
				throw new SinTintaException();
			}

			return  cantidad - this.tinta;
		}


        public override string ToString()
        {
            return $"{this.Id}, {this.Marca}, {this.Precio}, {this.Color}, {this.Tinta}";
        }

    }
}
