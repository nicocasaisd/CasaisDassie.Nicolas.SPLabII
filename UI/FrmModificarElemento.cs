using Biblioteca;
using Biblioteca.Persistencia;
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
        Cartuchera<Util> cartuchera;
        eModificarProductoOpcion opcion;
        Util elementoSeleccionado;
        

        public FrmModificarElemento()
        {
            InitializeComponent();
        }

        public FrmModificarElemento(Cartuchera<Util> cartuchera, eModificarProductoOpcion opcion) :this()
        {
            this.cartuchera = cartuchera;
            this.opcion = opcion;
        }
        public FrmModificarElemento(Cartuchera<Util> cartuchera, eModificarProductoOpcion opcion, Util util) : this(cartuchera, opcion)
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

        /// <summary>
        /// Modifica texto y visibilidad de los Labels de acuerdo al tipo de util seleccionado.
        /// </summary>
        /// <param name="tipo"></param>
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

        /// <summary>
        /// Si se modifica el util, asigna los valores a los campos correspondientes.
        /// </summary>
        /// <param name="tipo"></param>
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
                cmb_4.SelectedIndex = (int)lapiz.Color;
                chb_5.Checked = lapiz.EsMecanico;
            }
            else if(tipo == ETipoDeUtil.Goma)
            {
                Goma goma = (Goma)elementoSeleccionado;
                chb_5.Checked = goma.EsBorraTinta;
            }
            else
            {
                Sacapunta sacapunta = (Sacapunta)elementoSeleccionado;
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

        /// <summary>
        /// Modifica o Agrega el util a la base de datos según el tipo de útil pasado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string marca = txt_marca.Text;
            decimal precio = nud_precio.Value;

            if (opcion == eModificarProductoOpcion.AgregarProducto)
            {
                AgregarUtil(marca, precio);
            }
            else
            {
                ModificarUtil(marca, precio);
            }

            this.Close();
        }

        /// <summary>
        /// Modifica el util en la base de datos
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="precio"></param>
        private void ModificarUtil(string marca, decimal precio)
        {
            try
            {
                if (elementoSeleccionado is Lapiz)
                {
                    Lapiz lapiz = (Lapiz)elementoSeleccionado;
                    lapiz.Marca = marca;
                    lapiz.Precio = precio;
                    lapiz.Color = (EColorLapiz)cmb_4.SelectedItem;
                    lapiz.EsMecanico = chb_5.Checked;

                    UtilesDAO.ModificarUtil(lapiz);
                }
                else if (elementoSeleccionado is Goma)
                {
                    Goma goma = (Goma)elementoSeleccionado;
                    goma.Marca = marca;
                    goma.Precio = precio;
                    goma.EsBorraTinta = chb_5.Checked;
                    UtilesDAO.ModificarUtil(goma);
                }
                else if (elementoSeleccionado is Sacapunta)
                {
                    Sacapunta sacapunta = (Sacapunta)elementoSeleccionado;
                    sacapunta.Marca = marca;
                    sacapunta.Precio = precio;
                    sacapunta.Material = (EMaterialSacapunta)cmb_4.SelectedItem;
                    UtilesDAO.ModificarUtil(sacapunta);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
            
        }

        /// <summary>
        /// Agrega el util a la cartuchera. Si está llena lanza la excepción correspondiente.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="precio"></param>
        private void AgregarUtil(string marca, decimal precio)
        {
            try
            {
                if (cmb_tipoDeUtil.SelectedItem is ETipoDeUtil.Lapiz)
                {
                    EColorLapiz color = (EColorLapiz)cmb_4.SelectedItem;
                    bool esMecanico = chb_5.Checked;
                    Lapiz lapiz = new Lapiz(0, marca, precio, color, esMecanico);
                    _ = cartuchera + lapiz;
                }
                else if (cmb_tipoDeUtil.SelectedItem is ETipoDeUtil.Goma)
                {
                    bool esBorraTinta = chb_5.Checked;
                    Goma goma = new Goma(0, marca, precio, esBorraTinta);
                    _ = cartuchera + goma;
                }
                else if (cmb_tipoDeUtil.SelectedItem is ETipoDeUtil.Sacapunta)
                {
                    EMaterialSacapunta material = (EMaterialSacapunta)cmb_4.SelectedItem;
                    Sacapunta sacapunta = new Sacapunta(0, marca, precio, material);
                    _ = cartuchera + sacapunta;
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (CartucheraLlenaException)
            {
                MessageBox.Show("La cartuchera ha llegado al máximo de su capacidad.", "Cartuchera Llena.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
