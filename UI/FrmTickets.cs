using Biblioteca.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmTickets : Form
    {
        public FrmTickets()
        {
            InitializeComponent();
        }

        private void FrmTickets_Load(object sender, EventArgs e)
        {
            try
            {
                rtx_Tickets.Text = TicketManager.LeerTicket();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Aún no se han generado tickets. El archivo 'ticket.log' no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
    }
}
