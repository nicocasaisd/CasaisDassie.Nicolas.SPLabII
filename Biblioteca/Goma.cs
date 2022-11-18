using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Goma : Util
    {
        public Goma(int id, string nombre, decimal precio) : base(id, nombre, precio)
        {
            this.tipo = ETipoDeUtil.Goma;
        }
    }
}
