namespace UI
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpb_ListaCartuchera = new System.Windows.Forms.GroupBox();
            this.dgv_ListaCartuchera = new System.Windows.Forms.DataGridView();
            this.gpb_Crud = new System.Windows.Forms.GroupBox();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Modificar = new System.Windows.Forms.Button();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.gpb_ListaCartuchera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListaCartuchera)).BeginInit();
            this.gpb_Crud.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpb_ListaCartuchera
            // 
            this.gpb_ListaCartuchera.Controls.Add(this.dgv_ListaCartuchera);
            this.gpb_ListaCartuchera.Location = new System.Drawing.Point(12, 60);
            this.gpb_ListaCartuchera.Name = "gpb_ListaCartuchera";
            this.gpb_ListaCartuchera.Size = new System.Drawing.Size(586, 251);
            this.gpb_ListaCartuchera.TabIndex = 0;
            this.gpb_ListaCartuchera.TabStop = false;
            this.gpb_ListaCartuchera.Text = "Elementos de Cartuchera";
            // 
            // dgv_ListaCartuchera
            // 
            this.dgv_ListaCartuchera.AllowUserToAddRows = false;
            this.dgv_ListaCartuchera.AllowUserToDeleteRows = false;
            this.dgv_ListaCartuchera.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ListaCartuchera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ListaCartuchera.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_ListaCartuchera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ListaCartuchera.Location = new System.Drawing.Point(6, 22);
            this.dgv_ListaCartuchera.MultiSelect = false;
            this.dgv_ListaCartuchera.Name = "dgv_ListaCartuchera";
            this.dgv_ListaCartuchera.ReadOnly = true;
            this.dgv_ListaCartuchera.RowTemplate.Height = 25;
            this.dgv_ListaCartuchera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ListaCartuchera.Size = new System.Drawing.Size(574, 223);
            this.dgv_ListaCartuchera.TabIndex = 0;
            this.dgv_ListaCartuchera.SelectionChanged += new System.EventHandler(this.dgv_ListaCartuchera_SelectionChanged);
            // 
            // gpb_Crud
            // 
            this.gpb_Crud.Controls.Add(this.btn_Eliminar);
            this.gpb_Crud.Controls.Add(this.btn_Modificar);
            this.gpb_Crud.Controls.Add(this.btn_Agregar);
            this.gpb_Crud.Location = new System.Drawing.Point(12, 317);
            this.gpb_Crud.Name = "gpb_Crud";
            this.gpb_Crud.Size = new System.Drawing.Size(586, 69);
            this.gpb_Crud.TabIndex = 1;
            this.gpb_Crud.TabStop = false;
            this.gpb_Crud.Text = "Modificar Lista";
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Location = new System.Drawing.Point(286, 22);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(134, 35);
            this.btn_Eliminar.TabIndex = 2;
            this.btn_Eliminar.Text = "Eliminar Util";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // btn_Modificar
            // 
            this.btn_Modificar.Location = new System.Drawing.Point(146, 22);
            this.btn_Modificar.Name = "btn_Modificar";
            this.btn_Modificar.Size = new System.Drawing.Size(134, 35);
            this.btn_Modificar.TabIndex = 1;
            this.btn_Modificar.Text = "Modificar Util";
            this.btn_Modificar.UseVisualStyleBackColor = true;
            this.btn_Modificar.Click += new System.EventHandler(this.btn_Modificar_Click);
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Location = new System.Drawing.Point(6, 22);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(134, 35);
            this.btn_Agregar.TabIndex = 0;
            this.btn_Agregar.Text = "Agregar Util";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gpb_Crud);
            this.Controls.Add(this.gpb_ListaCartuchera);
            this.Name = "FrmPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.gpb_ListaCartuchera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListaCartuchera)).EndInit();
            this.gpb_Crud.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpb_ListaCartuchera;
        private System.Windows.Forms.DataGridView dgv_ListaCartuchera;
        private System.Windows.Forms.GroupBox gpb_Crud;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Modificar;
    }
}
