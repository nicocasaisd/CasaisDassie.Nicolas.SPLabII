using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Biblioteca;
using Biblioteca.Persistencia;
using Interfaces;

namespace UI
{
    public delegate void DelegadoCambioLista(object sender, EventArgs e);
    public delegate void DelegadoSinTinta(object sender, EventArgs e);

    public partial class FrmPrincipal : Form
    {
        #region ATRIBUTOS

        Cartuchera<Util> cartuchera;
        Util elementoSeleccionado;
        public event DelegadoCambioLista EventoCambioLista;
        // Hilos
        Task backup;
        CancellationToken token;
        CancellationTokenSource tokenSource;

        // PARCIAL
        Cartuchera<Fibron> cartucheraFibrones;
        public event DelegadoSinTinta SinTintaEvento;

        #endregion

        public FrmPrincipal()
        {
            InitializeComponent();
            token = new CancellationToken();
            tokenSource = new CancellationTokenSource();
            
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            cartuchera = CartucheraDAO.Leer();
            this.dgv_ListaCartuchera.DataSource = cartuchera.ListaElementos;
            this.txt_precioTotal.Text = cartuchera.PrecioTotal.ToString();
            
            // Eventos
            Cartuchera<Util>.EventoPrecio += ManejadoresDeEventos.EventoPrecio_Handler;
            this.EventoCambioLista += EventoCambioLista_Handler;
            this.EventoCambioLista += ManejadoresDeEventos.EventoCambioLista_HistorialDeAccionesHandler;
            
            // Hilo de backup
            backup = Task.Run(RealizarBackupYDormir, this.token);
            Task estadoDeBackup = Task.Run(InformarEstadoDeHilo);
        }

        

        private void dgv_ListaCartuchera_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListaCartuchera.SelectedRows.Count > 0)
            {
                this.elementoSeleccionado = (Util)dgv_ListaCartuchera.SelectedRows[0].DataBoundItem;
            }
        }

        /// <summary>
        /// Manejador de EventoCambioLista que actualiza el DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventoCambioLista_Handler(object sender, EventArgs e)
        {
            cartuchera = CartucheraDAO.Leer();
            this.dgv_ListaCartuchera.DataSource = cartuchera.ListaElementos;
            this.txt_precioTotal.Text = cartuchera.PrecioTotal.ToString();
            MessageBox.Show("Cambio realizado en la lista.");
        }


        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            FrmModificarElemento frmModificar = new FrmModificarElemento(cartuchera, eModificarProductoOpcion.AgregarProducto);
            frmModificar.ShowDialog();
            if (frmModificar.DialogResult == DialogResult.OK)
            {
                string metodoActual = MethodBase.GetCurrentMethod().Name;
                EventoCambioLista.Invoke(cartuchera, new EventoCambioListaArgs(metodoActual, null));
            }

        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            FrmModificarElemento frmModificar = new FrmModificarElemento(cartuchera, eModificarProductoOpcion.ModificarProducto, elementoSeleccionado);
            frmModificar.ShowDialog();
            if (frmModificar.DialogResult == DialogResult.OK)
            {
                string metodoActual = MethodBase.GetCurrentMethod().Name;
                EventoCambioLista.Invoke(cartuchera, new EventoCambioListaArgs(metodoActual, elementoSeleccionado));
            }

        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show($"Desea eliminar el elemento {elementoSeleccionado.Id},{elementoSeleccionado.Marca} ", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    UtilesDAO.EliminarPorId(elementoSeleccionado);
                    string metodoActual = MethodBase.GetCurrentMethod().Name;
                    EventoCambioLista.Invoke(cartuchera, new EventoCambioListaArgs(metodoActual, elementoSeleccionado));
                }
                catch (DataAccessObjectException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Muestra el historial de tickets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llb_historialDeTickets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            FrmTickets frmTickets = new FrmTickets();
            frmTickets.Show();
        }

        #region SERIALIZACION
        private void btn_SerializarXml_Click(object sender, EventArgs e)
        {
            try
            {
                ((ISerializa)elementoSeleccionado).Xml();
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Solo se pueden serializar elementos de tipo Lapiz.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception)
            {
                MessageBox.Show("Ocurrió un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_SerializarJson_Click(object sender, EventArgs e)
        {
            try
            {
                ((ISerializa)elementoSeleccionado).Json();
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Solo se pueden serializar elementos de tipo Lapiz.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_DeserializarXml_Click(object sender, EventArgs e)
        {
            if (ofd_Deserializar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Lapiz lapizDeserializado =(Lapiz) ((IDeserializa)elementoSeleccionado).Xml(ofd_Deserializar.FileName);
                    MessageBox.Show(lapizDeserializado.ToString());
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Solo se pueden deserializar archivos XML de tipo Lapiz.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrió un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_DeserializarJson_Click(object sender, EventArgs e)
        {
            if (ofd_Deserializar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Lapiz lapizDeserializado = (Lapiz)((IDeserializa)elementoSeleccionado).Json(ofd_Deserializar.FileName);
                    MessageBox.Show(lapizDeserializado.ToString());
                }
                catch (System.Text.Json.JsonException)
                {
                    MessageBox.Show("Solo se pueden deserializar archivos JSON de tipo Lapiz.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrió un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region BACKUP

        public void RealizarBackupYDormir()
        {
            while(!tokenSource.IsCancellationRequested)
            {
                try
                {
                    BackupManager.RealizarBackup(cartuchera);
                    tsslbl_mensaje.Text = $"Backup realizado - {DateTime.Now.ToShortTimeString()}";
                }
                catch (Exception)
                {
                    tsslbl_mensaje.Text = $"Error al realizar backup - {DateTime.Now.ToShortTimeString()}";
                }
                
                Thread.Sleep(30000);
                
            }
        }

        public void InformarEstadoDeHilo()
        {
            while(true)
            {
                tsslbl_hilo.Text = $"Estado del hilo backup: {this.backup.InformarEstado()}";
                Thread.Sleep(5000);
            }
        }

        private void llb_CancelarBackup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.tokenSource.Cancel();
        }
        #endregion


        //PARCIAL
        private void btn_InstanciarFibrones_Click(object sender, EventArgs e)
        {
            cartucheraFibrones = new Cartuchera<Fibron>(2, 10);

            Fibron fibronRojo = new Fibron(1, "FibronRojo", 0, 10, EColorLapiz.Rojo);
            Fibron fibronVerde = new Fibron(2, "FibronVerde", 0, 10, EColorLapiz.Verde);
            Fibron fibronAzul = new Fibron(3, "FibronAzul", 0, 10, EColorLapiz.Azul);

            cartucheraFibrones.ListaElementos.Add(fibronRojo);
            cartucheraFibrones.ListaElementos.Add(fibronVerde);
            cartucheraFibrones.ListaElementos.Add(fibronAzul);

            // Suscribo manejador
            SinTintaEvento += EventoSinTinta_Handler;
        }

        private void btn_Resaltar_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int index = rnd.Next(0, 2);
            int cantidadTinta = rnd.Next(1, 10);

            int tintaFaltante = 0;

            Fibron fibron = cartucheraFibrones.ListaElementos[index];

            try
            {
                tintaFaltante = fibron.Resaltar(cantidadTinta);
                MessageBox.Show($"Se gastó {cantidadTinta} en el fibrón {fibron}. \n Tinta restante: {fibron.Tinta}");

            }
            catch (SinTintaException)
            {
                if(this.SinTintaEvento is not null)
                {
                    SinTintaEvento.Invoke(this, new EventoSinTinta(tintaFaltante, fibron));
                }
               
            }
        }

        // Manejador
        private void EventoSinTinta_Handler(object sender, EventArgs e)
        {

            Util util = ((EventoSinTinta)e).util;
            int tintaFaltante = ((EventoSinTinta)e).tintaFaltante;

            TicketManager.EscribirErrores(tintaFaltante, util);
            MessageBox.Show("Se escribio el error en errors.log");
        }
    }
}
