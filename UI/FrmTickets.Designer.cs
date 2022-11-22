namespace UI
{
    partial class FrmTickets
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtx_Tickets = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtx_Tickets
            // 
            this.rtx_Tickets.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rtx_Tickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtx_Tickets.Location = new System.Drawing.Point(0, 0);
            this.rtx_Tickets.Name = "rtx_Tickets";
            this.rtx_Tickets.ReadOnly = true;
            this.rtx_Tickets.Size = new System.Drawing.Size(295, 359);
            this.rtx_Tickets.TabIndex = 0;
            this.rtx_Tickets.Text = "";
            // 
            // FrmTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 359);
            this.Controls.Add(this.rtx_Tickets);
            this.Name = "FrmTickets";
            this.Text = "FrmTickets";
            this.Load += new System.EventHandler(this.FrmTickets_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtx_Tickets;
    }
}