using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDeserializa
    {
        object Xml();
        object Json();
        object Xml(string path);
        object Json(string path);

    }
}
