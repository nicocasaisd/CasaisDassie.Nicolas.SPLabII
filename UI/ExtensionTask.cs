using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public static class ExtensionTask
    {
        public static string InformarEstado(this Task tarea)
        {
            return tarea.Status.ToString();
        }
    }
}
