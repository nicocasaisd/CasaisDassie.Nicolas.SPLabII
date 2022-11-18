﻿using System;
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

        public Sacapunta(int id, string marca, decimal precio, EMaterialSacapunta material) : base(id, marca, precio)
        {
            this.material = material;
            // defino tipo
            this.tipo = ETipoDeUtil.Sacapunta;
        }
    }
}
