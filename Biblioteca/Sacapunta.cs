using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public enum EMaterialSacapunta { Metal=1, Plastico=2}
    public class Sacapunta : Util
    {
        EMaterialSacapunta material;

        public Sacapunta(int id, string nombre, decimal precio, EMaterialSacapunta material) : base(id, nombre, precio)
        {
            this.material = material;
            // defino tipo
            this.tipo = ETipoDeUtil.Sacapunta;
        }
    }
}
