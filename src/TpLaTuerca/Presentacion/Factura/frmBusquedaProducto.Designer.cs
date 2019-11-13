namespace TpLaTuerca.Presentacion.Factura
{
    partial class frmBusquedaProducto
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBusqueda = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(222, 53);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(224, 26);
            this.txtNombre.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(469, 45);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(115, 42);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre de producto:";
            // 
            // dgvBusqueda
            // 
            this.dgvBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusqueda.Location = new System.Drawing.Point(31, 147);
            this.dgvBusqueda.Name = "dgvBusqueda";
            this.dgvBusqueda.RowHeadersWidth = 62;
            this.dgvBusqueda.RowTemplate.Height = 28;
            this.dgvBusqueda.Size = new System.Drawing.Size(672, 242);
            this.dgvBusqueda.TabIndex = 3;
            // 
            // frmBusquedaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 450);
            this.Controls.Add(this.dgvBusqueda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtNombre);
            this.Name = "frmBusquedaProducto";
            this.Text = "frmBusquedaProducto";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBusqueda;
    }
}