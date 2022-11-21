using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Persistencia
{
    public class DataAccessObjectException : Exception
    {
        public DataAccessObjectException(string mensaje) : base(mensaje)
        {

        }
    }
}
