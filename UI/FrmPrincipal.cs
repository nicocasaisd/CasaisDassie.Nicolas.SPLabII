using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;
using Biblioteca.Persistencia;

namespace UI
{
    public delegate void DelegadoCambioLista(object sender, EventArgs e);

    public partial class FrmPrincipal : Form
    {
        Cartuchera<Util> cartuchera;
        Util elementoSeleccionado;
        public event DelegadoCambioLista EventoCambioLista;

        public FrmPrincipal()
        {
            InitializeComponent();
            cartuchera = CartucheraDAO.Leer();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.dgv_ListaCartuchera.DataSource = cartuchera.ListaElementos;
            cartuchera.EventoPrecio += ManejadoresDeEventos.EventoPrecio_Handler;
            this.EventoCambioLista += EventoCambioLista_Handler;
        }

        

        private void dgv_ListaCartuchera_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListaCartuchera.SelectedRows.Count > 0)
            {
                this.elementoSeleccionado = (Util)dgv_ListaCartuchera.SelectedRows[0].DataBoundItem;
            }
        }

        private void EventoCambioLista_Handler(object sender, EventArgs e)
        {
            
            cartuchera = CartucheraDAO.Leer();
            this.dgv_ListaCartuchera.DataSource = cartuchera.ListaElementos;
            MessageBox.Show("Cambio realizado en la lista.");
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            FrmModificarElemento frmModificar = new FrmModificarElemento(cartuchera.Id_Cartuchera, eModificarProductoOpcion.AgregarProducto);
            frmModificar.ShowDialog();
            if (frmModificar.DialogResult == DialogResult.OK)
            {
                EventoCambioLista.Invoke(cartuchera, new EventArgs());
            }

        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            FrmModificarElemento frmModificar = new FrmModificarElemento(cartuchera.Id_Cartuchera, eModificarProductoOpcion.ModificarProducto, elementoSeleccionado);
            frmModificar.ShowDialog();
            if (frmModificar.DialogResult == DialogResult.OK)
            {
                EventoCambioLista.Invoke(cartuchera, new EventArgs());
            }
           
        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show($"Desea eliminar el elemento {elementoSeleccionado.Id},{elementoSeleccionado.Marca} ", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    UtilesDAO.EliminarPorId(elementoSeleccionado);
                    EventoCambioLista.Invoke(cartuchera, new EventArgs());
                }
                catch (DataAccessObjectException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void llb_historialDeTickets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmTickets frmTickets = new FrmTickets();
            frmTickets.Show();
        }
    }
}
