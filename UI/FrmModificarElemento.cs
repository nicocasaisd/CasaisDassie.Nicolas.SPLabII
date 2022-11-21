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
            AsignarValoresDeUtil(util.Tipo);
        }

        

        private void FrmModificarElemento_Load(object sender, EventArgs e)
        {
            if(opcion == eModificarProductoOpcion.AgregarProducto)
            {
                this.Text = "Agregar Util";
                Array eTipo = Enum.GetValues(typeof(ETipoDeUtil));
                cmb_tipoDeUtil.DataSource = eTipo;

            }
            else
            {
                this.Text = "Modificar Util";
                gpb_tipoDeUtil.Visible = false;
            }


        }

        private void AsignarOpcionesDeUtil(ETipoDeUtil tipo)
        {
            if (tipo == ETipoDeUtil.Lapiz)
            {
                lbl_4.Visible = true; lbl_4.Text = "Color:";
                cmb_4.Visible = true;
                Array eColor = Enum.GetValues(typeof(EColorLapiz));
                cmb_4.DataSource = eColor;
                chb_5.Visible = true; chb_5.Text = "Es mecánico?";
            }
            else if (tipo == ETipoDeUtil.Goma)
            {
                lbl_4.Visible = false; cmb_4.Visible = false;
                chb_5.Visible = true; chb_5.Text = "Es borratinta?";
            }
            else
            {
                lbl_4.Visible = true; lbl_4.Text = "Material:";
                cmb_4.Visible = true;
                Array eMaterial = Enum.GetValues(typeof(EMaterialSacapunta));
                cmb_4.DataSource = eMaterial;
                chb_5.Visible = false;
            }
        }

        private void AsignarValoresDeUtil(ETipoDeUtil tipo)
        {
            // Si el util ya existe, asigno los valores de util
            if (opcion == eModificarProductoOpcion.ModificarProducto)
            {
                txt_id.Text = elementoSeleccionado.Id.ToString();
                txt_marca.Text = elementoSeleccionado.Marca;
                nud_precio.Value = elementoSeleccionado.Precio;
            }
            
            if(tipo == ETipoDeUtil.Lapiz)
            {
                Lapiz lapiz = (Lapiz)elementoSeleccionado;
                // Si el util ya existe, asigno los valores de lapiz
                cmb_4.SelectedIndex = (int)lapiz.Color;
                chb_5.Checked = lapiz.EsMecanico;
            }
            else if(tipo == ETipoDeUtil.Goma)
            {
                Goma goma = (Goma)elementoSeleccionado;
                // Si el util ya existe, asigno los valores de goma
                chb_5.Checked = goma.EsBorraTinta;
            }
            else
            {
                Sacapunta sacapunta = (Sacapunta)elementoSeleccionado;
                // Si el util ya existe, asigno los valores de sacapunta
                cmb_4.SelectedIndex = (int)sacapunta.Material;
            }

        }

        private void cmb_tipoDeUtil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_tipoDeUtil.SelectedItem is ETipoDeUtil.Lapiz)
            {
                AsignarOpcionesDeUtil(ETipoDeUtil.Lapiz);
            }
            else if(cmb_tipoDeUtil.SelectedItem is ETipoDeUtil.Goma)
            {
                AsignarOpcionesDeUtil(ETipoDeUtil.Goma);
            }
            else
            {
                AsignarOpcionesDeUtil(ETipoDeUtil.Sacapunta);
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string marca = txt_marca.Text;
            decimal precio = nud_precio.Value;

            if (opcion == eModificarProductoOpcion.AgregarProducto)
            {

                if(cmb_tipoDeUtil.SelectedItem is ETipoDeUtil.Lapiz)
                {
                    EColorLapiz color = (EColorLapiz)cmb_4.SelectedItem;
                    bool esMecanico = chb_5.Checked;
                    Lapiz lapiz = new Lapiz(0, marca, precio,color, esMecanico)
                }
            }
        }
    }
}
