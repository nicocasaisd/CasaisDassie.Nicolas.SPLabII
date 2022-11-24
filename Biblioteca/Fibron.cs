using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Fibron : Util
    {
		private int tinta;
		private EColorLapiz color;

		public Fibron(int tinta, EColorLapiz color)
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


		public void Resaltar(int cantidad)
		{
			if(tinta >= cantidad)
			{

				this.tinta -= cantidad;
			}
			else
			{
				throw new SinTintaException();
			}
		}

		
	}
}
