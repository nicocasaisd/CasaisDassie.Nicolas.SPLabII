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
            AsignarOpcionesDeUtil(util.Tipo);
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

        private void AsignarOpcionesDeUtil(ETipoDeUtil tipo)
        {
            // Si el util ya existe, asigno los valores de util
            if (opcion == eModificarProductoOpcion.ModificarProducto)
            {
                txt_id.Text = elementoSeleccionado.Id.ToString();
                txt_marca.Text = elementoSeleccionado.Marca;
                nud_precio.Value = elementoSeleccionado.Precio;
            }

                if (tipo == ETipoDeUtil.Lapiz)
            {
                lbl_4.Text = "Color:";
                Array eColor = Enum.GetValues(typeof(EColorLapiz));
                cmb_4.DataSource = eColor;
                lbl_5.Text = "Es mecánico?";
                // Si el util ya existe, asigno los valores de lapiz
                if (opcion == eModificarProductoOpcion.ModificarProducto)
                {
                    Lapiz lapiz = (Lapiz)elementoSeleccionado;
                    cmb_4.SelectedIndex = (int)lapiz.Color;


                }
            }
        }
    }
}
