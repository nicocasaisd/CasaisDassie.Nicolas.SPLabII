using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Sacapunta : Util
    {
        public Sacapunta(int id, string nombre, decimal precio) : base(id, nombre, precio)
        {
            this.tipo = ETipoDeUtil.Sacapunta;
        }
    }
}
