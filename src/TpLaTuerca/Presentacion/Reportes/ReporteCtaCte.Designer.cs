namespace TpLaTuerca.Presentacion.Reportes
{
    partial class ReporteCtaCte
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dTReporteBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dsCtaCte = new TpLaTuerca.Presentacion.Reportes.DataSets.dsCtaCte();
            this.rpvCtaCte = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dTReporteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCtaCteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCtaCteBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dTReporteBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dTReporteBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCtaCte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTReporteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCtaCteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCtaCteBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTReporteBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dTReporteBindingSource2
            // 
            this.dTReporteBindingSource2.DataMember = "DTReporte";
            this.dTReporteBindingSource2.DataSource = this.dsCtaCte;
            // 
            // dsCtaCte
            // 
            this.dsCtaCte.DataSetName = "dsCtaCte";
            this.dsCtaCte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpvCtaCte
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dTReporteBindingSource2;
            this.rpvCtaCte.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvCtaCte.LocalReport.ReportEmbeddedResource = "TpLaTuerca.Presentacion.Reportes.Diseño.rpCtaCte.rdlc";
            this.rpvCtaCte.Location = new System.Drawing.Point(12, 56);
            this.rpvCtaCte.Name = "rpvCtaCte";
            this.rpvCtaCte.Size = new System.Drawing.Size(675, 342);
            this.rpvCtaCte.TabIndex = 0;
            this.rpvCtaCte.Load += new System.EventHandler(this.rpvCtaCte_Load);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(12, 12);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(79, 38);
            this.btnGenerar.TabIndex = 1;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // dTReporteBindingSource
            // 
            this.dTReporteBindingSource.DataMember = "DTReporte";
            this.dTReporteBindingSource.DataSource = this.dsCtaCte;
            // 
            // dsCtaCteBindingSource
            // 
            this.dsCtaCteBindingSource.DataSource = this.dsCtaCte;
            this.dsCtaCteBindingSource.Position = 0;
            // 
            // dsCtaCteBindingSource1
            // 
            this.dsCtaCteBindingSource1.DataSource = this.dsCtaCte;
            this.dsCtaCteBindingSource1.Position = 0;
            // 
            // dTReporteBindingSource1
            // 
            this.dTReporteBindingSource1.DataMember = "DTReporte";
            this.dTReporteBindingSource1.DataSource = this.dsCtaCte;
            // 
            // ReporteCtaCte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 400);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.rpvCtaCte);
            this.Name = "ReporteCtaCte";
            this.Text = "ReporteCtaCte";
            this.Load += new System.EventHandler(this.ReporteCtaCte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dTReporteBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCtaCte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTReporteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCtaCteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCtaCteBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTReporteBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvCtaCte;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.BindingSource dsCtaCteBindingSource;
        private DataSets.dsCtaCte dsCtaCte;
        private System.Windows.Forms.BindingSource dsCtaCteBindingSource1;
        private System.Windows.Forms.BindingSource dTReporteBindingSource;
        private System.Windows.Forms.BindingSource dTReporteBindingSource1;
        private System.Windows.Forms.BindingSource dTReporteBindingSource2;
    }
}