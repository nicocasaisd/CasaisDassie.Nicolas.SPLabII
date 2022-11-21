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
            this.chb_5 = new System.Windows.Forms.CheckBox();
            this.cmb_4 = new System.Windows.Forms.ComboBox();
            this.lbl_4 = new System.Windows.Forms.Label();
            this.nud_precio = new System.Windows.Forms.NumericUpDown();
            this.txt_marca = new System.Windows.Forms.TextBox();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.lbl_precio = new System.Windows.Forms.Label();
            this.lbl_marca = new System.Windows.Forms.Label();
            this.lbl_id = new System.Windows.Forms.Label();
            this.gpb_tipoDeUtil = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpb_Controles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_precio)).BeginInit();
            this.gpb_tipoDeUtil.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpb_Controles
            // 
            this.gpb_Controles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpb_Controles.Controls.Add(this.chb_5);
            this.gpb_Controles.Controls.Add(this.cmb_4);
            this.gpb_Controles.Controls.Add(this.lbl_4);
            this.gpb_Controles.Controls.Add(this.nud_precio);
            this.gpb_Controles.Controls.Add(this.txt_marca);
            this.gpb_Controles.Controls.Add(this.txt_id);
            this.gpb_Controles.Controls.Add(this.lbl_precio);
            this.gpb_Controles.Controls.Add(this.lbl_marca);
            this.gpb_Controles.Controls.Add(this.lbl_id);
            this.gpb_Controles.Location = new System.Drawing.Point(12, 57);
            this.gpb_Controles.Name = "gpb_Controles";
            this.gpb_Controles.Size = new System.Drawing.Size(250, 209);
            this.gpb_Controles.TabIndex = 0;
            this.gpb_Controles.TabStop = false;
            // 
            // chb_5
            // 
            this.chb_5.AutoSize = true;
            this.chb_5.Location = new System.Drawing.Point(109, 177);
            this.chb_5.Name = "chb_5";
            this.chb_5.Size = new System.Drawing.Size(29, 19);
            this.chb_5.TabIndex = 9;
            this.chb_5.Text = " ";
            this.chb_5.UseVisualStyleBackColor = true;
            // 
            // cmb_4
            // 
            this.cmb_4.FormattingEnabled = true;
            this.cmb_4.Location = new System.Drawing.Point(107, 133);
            this.cmb_4.Name = "cmb_4";
            this.cmb_4.Size = new System.Drawing.Size(121, 23);
            this.cmb_4.TabIndex = 8;
            // 
            // lbl_4
            // 
            this.lbl_4.AutoSize = true;
            this.lbl_4.Location = new System.Drawing.Point(8, 133);
            this.lbl_4.Name = "lbl_4";
            this.lbl_4.Size = new System.Drawing.Size(38, 15);
            this.lbl_4.TabIndex = 6;
            this.lbl_4.Text = "label1";
            // 
            // nud_precio
            // 
            this.nud_precio.Location = new System.Drawing.Point(108, 99);
            this.nud_precio.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nud_precio.Name = "nud_precio";
            this.nud_precio.Size = new System.Drawing.Size(120, 23);
            this.nud_precio.TabIndex = 5;
            // 
            // txt_marca
            // 
            this.txt_marca.Location = new System.Drawing.Point(109, 59);
            this.txt_marca.Name = "txt_marca";
            this.txt_marca.Size = new System.Drawing.Size(119, 23);
            this.txt_marca.TabIndex = 4;
            // 
            // txt_id
            // 
            this.txt_id.Enabled = false;
            this.txt_id.Location = new System.Drawing.Point(109, 22);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(119, 23);
            this.txt_id.TabIndex = 3;
            // 
            // lbl_precio
            // 
            this.lbl_precio.AutoSize = true;
            this.lbl_precio.Location = new System.Drawing.Point(6, 101);
            this.lbl_precio.Name = "lbl_precio";
            this.lbl_precio.Size = new System.Drawing.Size(43, 15);
            this.lbl_precio.TabIndex = 2;
            this.lbl_precio.Text = "Precio:";
            // 
            // lbl_marca
            // 
            this.lbl_marca.AutoSize = true;
            this.lbl_marca.Location = new System.Drawing.Point(6, 67);
            this.lbl_marca.Name = "lbl_marca";
            this.lbl_marca.Size = new System.Drawing.Size(43, 15);
            this.lbl_marca.TabIndex = 1;
            this.lbl_marca.Text = "Marca:";
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(6, 36);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(21, 15);
            this.lbl_id.TabIndex = 0;
            this.lbl_id.Text = "ID:";
            // 
            // gpb_tipoDeUtil
            // 
            this.gpb_tipoDeUtil.Controls.Add(this.label1);
            this.gpb_tipoDeUtil.Location = new System.Drawing.Point(12, 3);
            this.gpb_tipoDeUtil.Name = "gpb_tipoDeUtil";
            this.gpb_tipoDeUtil.Size = new System.Drawing.Size(250, 48);
            this.gpb_tipoDeUtil.TabIndex = 1;
            this.gpb_tipoDeUtil.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de útil:";
            // 
            // FrmModificarElemento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 278);
            this.Controls.Add(this.gpb_tipoDeUtil);
            this.Controls.Add(this.gpb_Controles);
            this.Name = "FrmModificarElemento";
            this.Text = "FrmModificarElemento";
            this.Load += new System.EventHandler(this.FrmModificarElemento_Load);
            this.gpb_Controles.ResumeLayout(false);
            this.gpb_Controles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_precio)).EndInit();
            this.gpb_tipoDeUtil.ResumeLayout(false);
            this.gpb_tipoDeUtil.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpb_Controles;
        private System.Windows.Forms.Label lbl_precio;
        private System.Windows.Forms.Label lbl_marca;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.TextBox txt_marca;
        private System.Windows.Forms.NumericUpDown nud_precio;
        private System.Windows.Forms.Label lbl_4;
        private System.Windows.Forms.CheckBox chb_5;
        private System.Windows.Forms.ComboBox cmb_4;
        private System.Windows.Forms.GroupBox gpb_tipoDeUtil;
        private System.Windows.Forms.Label label1;
    }
}