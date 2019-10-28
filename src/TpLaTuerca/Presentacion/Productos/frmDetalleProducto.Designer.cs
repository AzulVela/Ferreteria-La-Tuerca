namespace TpLaTuerca.Presentacion.Productos
{
    partial class frmDetalleProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleProducto));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tbcDetalle = new System.Windows.Forms.TabControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTipoUso = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTipoMedida = new System.Windows.Forms.ComboBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.cboProveedores = new System.Windows.Forms.TabPage();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbcDetalle.SuspendLayout();
            this.cboProveedores.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(342, 545);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 35);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(220, 545);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(112, 35);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // tbcDetalle
            // 
            this.tbcDetalle.Controls.Add(this.cboProveedores);
            this.tbcDetalle.Location = new System.Drawing.Point(-2, 0);
            this.tbcDetalle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbcDetalle.Name = "tbcDetalle";
            this.tbcDetalle.SelectedIndex = 0;
            this.tbcDetalle.Size = new System.Drawing.Size(585, 513);
            this.tbcDetalle.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 183);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 20);
            this.label7.TabIndex = 37;
            // 
            // cboTipoUso
            // 
            this.cboTipoUso.FormattingEnabled = true;
            this.cboTipoUso.Location = new System.Drawing.Point(158, 122);
            this.cboTipoUso.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTipoUso.Name = "cboTipoUso";
            this.cboTipoUso.Size = new System.Drawing.Size(288, 28);
            this.cboTipoUso.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 130);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 42;
            // 
            // cboTipoMedida
            // 
            this.cboTipoMedida.FormattingEnabled = true;
            this.cboTipoMedida.Location = new System.Drawing.Point(158, 179);
            this.cboTipoMedida.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTipoMedida.Name = "cboTipoMedida";
            this.cboTipoMedida.Size = new System.Drawing.Size(288, 28);
            this.cboTipoMedida.TabIndex = 4;
            this.cboTipoMedida.SelectedIndexChanged += new System.EventHandler(this.CboTipoMedida_SelectedIndexChanged);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(158, 68);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(288, 26);
            this.txtPrecio.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(158, 14);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(288, 26);
            this.txtNombre.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(158, 286);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(288, 152);
            this.txtDescripcion.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 286);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 239);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 48;
            // 
            // cboProveedor
            // 
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Location = new System.Drawing.Point(158, 230);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(288, 28);
            this.cboProveedor.TabIndex = 5;
            // 
            // cboProveedores
            // 
            this.cboProveedores.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboProveedores.Controls.Add(this.label11);
            this.cboProveedores.Controls.Add(this.label10);
            this.cboProveedores.Controls.Add(this.label9);
            this.cboProveedores.Controls.Add(this.label8);
            this.cboProveedores.Controls.Add(this.label6);
            this.cboProveedores.Controls.Add(this.lblNombre);
            this.cboProveedores.Controls.Add(this.cboProveedor);
            this.cboProveedores.Controls.Add(this.label4);
            this.cboProveedores.Controls.Add(this.label3);
            this.cboProveedores.Controls.Add(this.txtDescripcion);
            this.cboProveedores.Controls.Add(this.txtNombre);
            this.cboProveedores.Controls.Add(this.txtPrecio);
            this.cboProveedores.Controls.Add(this.cboTipoMedida);
            this.cboProveedores.Controls.Add(this.label5);
            this.cboProveedores.Controls.Add(this.cboTipoUso);
            this.cboProveedores.Controls.Add(this.label7);
            this.cboProveedores.Controls.Add(this.label1);
            this.cboProveedores.Controls.Add(this.label2);
            this.cboProveedores.Location = new System.Drawing.Point(4, 29);
            this.cboProveedores.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboProveedores.Name = "cboProveedores";
            this.cboProveedores.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboProveedores.Size = new System.Drawing.Size(577, 480);
            this.cboProveedores.TabIndex = 0;
            this.cboProveedores.Text = "Detalle";
            this.cboProveedores.Click += new System.EventHandler(this.CboProveedores_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(44, 17);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(69, 20);
            this.lblNombre.TabIndex = 49;
            this.lblNombre.Text = "Nombre:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 50;
            this.label6.Text = "Precio:";
            this.label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 51;
            this.label8.Text = "Tipo uso:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 52;
            this.label9.Text = "Tipo medida:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(44, 233);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 20);
            this.label10.TabIndex = 53;
            this.label10.Text = "Proveedor";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 289);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 20);
            this.label11.TabIndex = 54;
            this.label11.Text = "Descripción:";
            // 
            // frmDetalleProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 602);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.tbcDetalle);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDetalleProducto";
            this.Text = "Detalle Producto";
            this.Load += new System.EventHandler(this.FrmDetalleProducto_Load);
            this.tbcDetalle.ResumeLayout(false);
            this.cboProveedores.ResumeLayout(false);
            this.cboProveedores.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TabControl tbcDetalle;
        private System.Windows.Forms.TabPage cboProveedores;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.ComboBox cboTipoMedida;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTipoUso;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}