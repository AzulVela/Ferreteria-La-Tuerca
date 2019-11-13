using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpLaTuerca.LogicaNegocio;

namespace TpLaTuerca.Presentacion.Cuenta_Corriente
{
    public partial class frmListaClientes : Form
    {
        public ClienteService oClienteService;

        public Entidades.Cliente clienteSeleccionado { get; set; }

        frmCuentaCorriente formularioCuenta;

        public frmListaClientes(frmCuentaCorriente formularioCuenta)
        {
            InitializeComponent();
            InitializeDataGridView();

            oClienteService = new ClienteService();
            clienteSeleccionado = new Entidades.Cliente();

            this.formularioCuenta = formularioCuenta;

        }

        internal void CargarClientes(Dictionary<string, object> filtros)
        {
            dgvListaClientes.DataSource = oClienteService.ConsultarConFiltros(filtros);
        }

        private void FrmListaClientes_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            DataGridViewColumn ColumnaCod = dgvListaClientes.Columns[0];
            ColumnaCod.Visible = false;
            DataGridViewColumn ColumnaTel = dgvListaClientes.Columns[3];
            ColumnaTel.Visible = false;
        }

        private void InitializeDataGridView()
        {
            dgvListaClientes.ColumnCount = 5;
            dgvListaClientes.ColumnHeadersVisible = true;

            dgvListaClientes.AutoGenerateColumns = false;

            dgvListaClientes.Columns[0].Name = "Codigo Cliente";
            dgvListaClientes.Columns[0].DataPropertyName = "CodCliente";

            dgvListaClientes.Columns[1].Name = "Apellido";
            dgvListaClientes.Columns[1].DataPropertyName = "Apellido";

            dgvListaClientes.Columns[2].Name = "Nombre";
            dgvListaClientes.Columns[2].DataPropertyName = "Nombre";

            dgvListaClientes.Columns[3].Name = "Telefono";
            dgvListaClientes.Columns[3].DataPropertyName = "Telefono";

            dgvListaClientes.Columns[4].Name = "CUIT";
            dgvListaClientes.Columns[4].DataPropertyName = "CUIT";
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            clienteSeleccionado = (Entidades.Cliente)dgvListaClientes.CurrentRow.DataBoundItem;
            formularioCuenta.TomarCliente();
            this.Close();
        }
    }
}
