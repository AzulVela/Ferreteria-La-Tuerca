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
using TpLaTuerca.Presentación.Clientes;

namespace TpLaTuerca.Presentación.Cliente
{
    public partial class frmClientes : Form
    {

        private ClienteService oClienteService; 
        public frmClientes()
        {
            oClienteService = new ClienteService();
            InitializeComponent();
            InitializeDataGridView();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            DataGridViewColumn ColumnaCod = dgvClientes.Columns[0];
            ColumnaCod.Visible = false;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmABMCliente formulario = new frmABMCliente();
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            var filtros = new Dictionary<string, object>();

            if (!chkTodos.Checked)
            {
                if (txtNombre.Text != string.Empty)
                {
                    filtros.Add("Nombre", '%'+txtNombre.Text+'%');
                }

                if (txtApellido.Text != string.Empty)
                {
                    filtros.Add("Apellido", '%'+txtApellido.Text+'%');
                }

                if (filtros.Count > 0)
                    dgvClientes.DataSource = oClienteService.ConsultarConFiltros(filtros);
                else
                    MessageBox.Show("Se debe ingresar al menos un criterio de búsqueda", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            else
                dgvClientes.DataSource = oClienteService.ObtenerTodos();
            
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            frmABMCliente formulario = new frmABMCliente();
            var cliente = (Entidades.Cliente)dgvClientes.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(frmABMCliente.FormMode.update, cliente);
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void ChkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked == true)
            {
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
            }
            else
            { 
                txtApellido.Enabled = true;
                txtNombre.Enabled = true;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            frmABMCliente formulario = new frmABMCliente();
            var cliente = (Entidades.Cliente)dgvClientes.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(frmABMCliente.FormMode.delete, cliente);
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNuevo.Enabled = true;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void DgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InitializeDataGridView()
        {
            dgvClientes.ColumnCount = 5;
            dgvClientes.ColumnHeadersVisible = true;

            dgvClientes.AutoGenerateColumns = false;

            dgvClientes.Columns[0].Name = "Codigo Cliente";
            dgvClientes.Columns[0].DataPropertyName = "CodCliente";

            dgvClientes.Columns[1].Name = "Apellido";
            dgvClientes.Columns[1].DataPropertyName = "Apellido";

            dgvClientes.Columns[2].Name = "Nombre";
            dgvClientes.Columns[2].DataPropertyName = "Nombre";

            dgvClientes.Columns[3].Name = "Telefono";
            dgvClientes.Columns[3].DataPropertyName = "Telefono";

            dgvClientes.Columns[4].Name = "CUIT";
            dgvClientes.Columns[4].DataPropertyName = "CUIT";
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
