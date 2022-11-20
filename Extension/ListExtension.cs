using Biblioteca;
using Persistencia;
using System;
using System.Collections.Generic;

namespace Extension
{
    public static class ListExtension
    {
        public static void AgregarUtil(this List<Util> lista, int id, Util util)
        {
            UtilesDAO.GuardarUtil(id, util);
        }
    }
}
