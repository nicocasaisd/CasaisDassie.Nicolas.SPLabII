using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDeserializa
    {
        string Xml(object obj);
        string Json(object obj);
    }
}
