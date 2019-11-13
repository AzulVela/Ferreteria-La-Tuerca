namespace TpLaTuerca.Presentacion.Factura
{
    partial class frmFactura
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
            this.cboTipoFactura = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cboVendedor = new System.Windows.Forms.ComboBox();
            this.dpbDetalle = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuitarItem = new System.Windows.Forms.Button();
            this.btnAgregarItem = new System.Windows.Forms.Button();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.dpbDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTipoFactura
            // 
            this.cboTipoFactura.FormattingEnabled = true;
            this.cboTipoFactura.Location = new System.Drawing.Point(138, 20);
            this.cboTipoFactura.Name = "cboTipoFactura";
            this.cboTipoFactura.Size = new System.Drawing.Size(121, 28);
            this.cboTipoFactura.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo Factura:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente:";
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(338, 20);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(121, 28);
            this.cboCliente.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(856, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(920, 17);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(160, 26);
            this.dtpFecha.TabIndex = 99;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Vendedor:";
            // 
            // cboVendedor
            // 
            this.cboVendedor.FormattingEnabled = true;
            this.cboVendedor.Location = new System.Drawing.Point(570, 18);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Size = new System.Drawing.Size(121, 28);
            this.cboVendedor.TabIndex = 2;
            // 
            // dpbDetalle
            // 
            this.dpbDetalle.Controls.Add(this.btnBuscar);
            this.dpbDetalle.Controls.Add(this.label9);
            this.dpbDetalle.Controls.Add(this.txtTotal);
            this.dpbDetalle.Controls.Add(this.txtCantidad);
            this.dpbDetalle.Controls.Add(this.dgvDetalle);
            this.dpbDetalle.Controls.Add(this.btnQuitarItem);
            this.dpbDetalle.Controls.Add(this.btnAgregarItem);
            this.dpbDetalle.Controls.Add(this.txtImporte);
            this.dpbDetalle.Controls.Add(this.txtPrecio);
            this.dpbDetalle.Controls.Add(this.label8);
            this.dpbDetalle.Controls.Add(this.label7);
            this.dpbDetalle.Controls.Add(this.label6);
            this.dpbDetalle.Controls.Add(this.label5);
            this.dpbDetalle.Location = new System.Drawing.Point(12, 89);
            this.dpbDetalle.Name = "dpbDetalle";
            this.dpbDetalle.Size = new System.Drawing.Size(1068, 426);
            this.dpbDetalle.TabIndex = 8;
            this.dpbDetalle.TabStop = false;
            this.dpbDetalle.Text = "Detalle";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(89, 33);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(104, 37);
            this.btnBuscar.TabIndex = 22;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(890, 382);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(944, 378);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 26);
            this.txtTotal.TabIndex = 20;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(310, 37);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 26);
            this.txtCantidad.TabIndex = 4;
            this.txtCantidad.Leave += new System.EventHandler(this.TxtCantidad_Leave);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToOrderColumns = true;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.cantidad,
            this.precio,
            this.importe});
            this.dgvDetalle.Location = new System.Drawing.Point(10, 92);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersWidth = 62;
            this.dgvDetalle.RowTemplate.Height = 28;
            this.dgvDetalle.ShowCellToolTips = false;
            this.dgvDetalle.Size = new System.Drawing.Size(1034, 271);
            this.dgvDetalle.TabIndex = 18;
            this.dgvDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalle_CellContentClick);
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "Nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.MinimumWidth = 8;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 150;
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "Cantidad";
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.MinimumWidth = 8;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 150;
            // 
            // precio
            // 
            this.precio.DataPropertyName = "PrecioU";
            this.precio.HeaderText = "Precio";
            this.precio.MinimumWidth = 8;
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            this.precio.Width = 150;
            // 
            // importe
            // 
            this.importe.DataPropertyName = "Importe";
            this.importe.HeaderText = "Importe";
            this.importe.MinimumWidth = 8;
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            this.importe.Width = 150;
            // 
            // btnQuitarItem
            // 
            this.btnQuitarItem.Image = global::TpLaTuerca.Properties.Resources.eliminar;
            this.btnQuitarItem.Location = new System.Drawing.Point(994, 26);
            this.btnQuitarItem.Name = "btnQuitarItem";
            this.btnQuitarItem.Size = new System.Drawing.Size(50, 48);
            this.btnQuitarItem.TabIndex = 17;
            this.btnQuitarItem.UseVisualStyleBackColor = true;
            this.btnQuitarItem.Click += new System.EventHandler(this.BtnQuitarItem_Click);
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.Image = global::TpLaTuerca.Properties.Resources.agregar;
            this.btnAgregarItem.Location = new System.Drawing.Point(934, 26);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Size = new System.Drawing.Size(50, 48);
            this.btnAgregarItem.TabIndex = 5;
            this.btnAgregarItem.UseVisualStyleBackColor = true;
            this.btnAgregarItem.Click += new System.EventHandler(this.BtnAgregarItem_Click);
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(716, 37);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(100, 26);
            this.txtImporte.TabIndex = 15;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(516, 38);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 26);
            this.txtPrecio.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(642, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Importe:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(452, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Precio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(228, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Cantidad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Producto:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(807, 522);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 45);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoEllipsis = true;
            this.btnGuardar.Location = new System.Drawing.Point(938, 522);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 45);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // cboProducto
            // 
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(707, 19);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(121, 28);
            this.cboProducto.TabIndex = 3;
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.CboProducto_SelectedIndexChanged);
            // 
            // frmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 578);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dpbDetalle);
            this.Controls.Add(this.cboVendedor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTipoFactura);
            this.Controls.Add(this.cboProducto);
            this.Name = "frmFactura";
            this.Text = "NuevaFactura";
            this.Load += new System.EventHandler(this.FrmFactura_Load);
            this.dpbDetalle.ResumeLayout(false);
            this.dpbDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTipoFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboVendedor;
        private System.Windows.Forms.GroupBox dpbDetalle;
        private System.Windows.Forms.Button btnAgregarItem;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnQuitarItem;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.Button btnBuscar;
    }
}