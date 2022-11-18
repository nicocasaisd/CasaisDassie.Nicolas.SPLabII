using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Goma : Util
    {
        private bool esBorraTinta;

        public Goma(int id, string nombre, decimal precio, bool esBorraTinta) : base(id, nombre, precio)
        {
            this.esBorraTinta = esBorraTinta;
            // defino tipo
            this.tipo = ETipoDeUtil.Goma;
        }
    }
}
