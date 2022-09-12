namespace Forms
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.dgvComercio = new System.Windows.Forms.DataGridView();
            this.picboxArticulo = new System.Windows.Forms.PictureBox();
            this.lblFiltroRapido = new System.Windows.Forms.Label();
            this.txtboxFiltroRapido = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComercio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAgregar.Location = new System.Drawing.Point(20, 308);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(115, 28);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar Articulo";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(150, 308);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(122, 28);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar Articulo";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(296, 308);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(122, 28);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar Articulo";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // dgvComercio
            // 
            this.dgvComercio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComercio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvComercio.Location = new System.Drawing.Point(20, 62);
            this.dgvComercio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvComercio.MultiSelect = false;
            this.dgvComercio.Name = "dgvComercio";
            this.dgvComercio.RowHeadersWidth = 51;
            this.dgvComercio.RowTemplate.Height = 24;
            this.dgvComercio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComercio.Size = new System.Drawing.Size(538, 241);
            this.dgvComercio.TabIndex = 4;
            this.dgvComercio.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvComercio_DataError);
            this.dgvComercio.SelectionChanged += new System.EventHandler(this.dgvComercio_SelectionChanged);
            // 
            // picboxArticulo
            // 
            this.picboxArticulo.Location = new System.Drawing.Point(563, 62);
            this.picboxArticulo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picboxArticulo.Name = "picboxArticulo";
            this.picboxArticulo.Size = new System.Drawing.Size(219, 241);
            this.picboxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxArticulo.TabIndex = 5;
            this.picboxArticulo.TabStop = false;
            // 
            // lblFiltroRapido
            // 
            this.lblFiltroRapido.AutoSize = true;
            this.lblFiltroRapido.Location = new System.Drawing.Point(18, 31);
            this.lblFiltroRapido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltroRapido.Name = "lblFiltroRapido";
            this.lblFiltroRapido.Size = new System.Drawing.Size(69, 13);
            this.lblFiltroRapido.TabIndex = 6;
            this.lblFiltroRapido.Text = "Filtro Rápido:";
            // 
            // txtboxFiltroRapido
            // 
            this.txtboxFiltroRapido.Location = new System.Drawing.Point(96, 28);
            this.txtboxFiltroRapido.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtboxFiltroRapido.Name = "txtboxFiltroRapido";
            this.txtboxFiltroRapido.Size = new System.Drawing.Size(192, 20);
            this.txtboxFiltroRapido.TabIndex = 7;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 407);
            this.Controls.Add(this.txtboxFiltroRapido);
            this.Controls.Add(this.lblFiltroRapido);
            this.Controls.Add(this.picboxArticulo);
            this.Controls.Add(this.dgvComercio);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comercio";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComercio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridView dgvComercio;
        private System.Windows.Forms.PictureBox picboxArticulo;
        private System.Windows.Forms.Label lblFiltroRapido;
        private System.Windows.Forms.TextBox txtboxFiltroRapido;
    }
}

