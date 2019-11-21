using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpLaTuerca.Presentacion.Reportes
{
    public partial class ReporteCtaCte : Form
    {
        public ReporteCtaCte()
        {
            InitializeComponent();
        }

        private void ReporteCtaCte_Load(object sender, EventArgs e)
        {

            this.rpvCtaCte.RefreshReport();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            rpvCtaCte.LocalReport.DataSources.Clear();
            rpvCtaCte.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataManager.GetInstance().GenerarReporte()));
            rpvCtaCte.RefreshReport();
        }

        private void rpvCtaCte_Load(object sender, EventArgs e)
        {

        }
    }
}
