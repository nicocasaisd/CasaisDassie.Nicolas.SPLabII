using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class SinTintaException : Exception
    {
        public int tintaFaltante;
        public SinTintaException(int tintaFaltante) : base()
        {
            this.tintaFaltante = tintaFaltante;
        }
    }
}
