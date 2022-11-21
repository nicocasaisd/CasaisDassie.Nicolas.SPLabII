using Biblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public enum eModificarProductoOpcion
    {
        ModificarProducto, AgregarProducto
    }

    public partial class FrmModificarElemento : Form
    {
        eModificarProductoOpcion opcion;
        Util elementoSeleccionado;

        public FrmModificarElemento()
        {
            InitializeComponent();
        }

        public FrmModificarElemento(eModificarProductoOpcion opcion) :this()
        {
            this.opcion = opcion;
        }
        public FrmModificarElemento(eModificarProductoOpcion opcion, Util util) : this(opcion)
        {
            this.elementoSeleccionado = util;
        }

        private void FrmModificarElemento_Load(object sender, EventArgs e)
        {
            if(opcion == eModificarProductoOpcion.AgregarProducto)
            {
                this.Text = "Agregar Util";
            }
            else
            {
                this.Text = "Modificar Util";
            }


        }
    }
}
