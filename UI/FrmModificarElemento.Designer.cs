namespace UI
{
    partial class FrmModificarElemento
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
            this.gpb_Controles = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // gpb_Controles
            // 
            this.gpb_Controles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpb_Controles.Location = new System.Drawing.Point(12, 12);
            this.gpb_Controles.Name = "gpb_Controles";
            this.gpb_Controles.Size = new System.Drawing.Size(291, 352);
            this.gpb_Controles.TabIndex = 0;
            this.gpb_Controles.TabStop = false;
            this.gpb_Controles.Text = " ";
            // 
            // FrmModificarElemento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 372);
            this.Controls.Add(this.gpb_Controles);
            this.Name = "FrmModificarElemento";
            this.Text = "FrmModificarElemento";
            this.Load += new System.EventHandler(this.FrmModificarElemento_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpb_Controles;
    }
}