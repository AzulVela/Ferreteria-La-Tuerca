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

namespace TpLaTuerca.Presentación.Proveedor
{
    public partial class frmProveedores : Form
    {
        private ProveedorService oProveedorService;

        public frmProveedores()
        {
            InitializeComponent();
            InitializeDataGridView();
            oProveedorService = new ProveedorService();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            DataGridViewColumn ColumnaCod = dgvProveedores.Columns[0];
            ColumnaCod.Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            var filtros = new Dictionary<string, object>();

            if (!chkTodos.Checked)
            {
                if (txtNombre.Text != string.Empty)
                    filtros.Add("Nombre",'%'+txtNombre.Text+'%');

                if (txtApellido.Text != string.Empty)
                    filtros.Add("Apellido",'%'+txtApellido.Text+'%');

                if (filtros.Count > 0)
                    dgvProveedores.DataSource = oProveedorService.ConsultarConFiltros(filtros);

                else
                    MessageBox.Show("Debe ingresarse al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                dgvProveedores.DataSource = oProveedorService.ObtenerTodos(filtros);
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ChkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
            }
            else
            {
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
            }
        }

        private void DgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmABMProveedor formulario = new frmABMProveedor();
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            frmABMProveedor formulario = new frmABMProveedor();
            var proveedor = (Entidades.Proveedor)dgvProveedores.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(frmABMProveedor.FormMode.update, proveedor);
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            frmABMProveedor formulario = new frmABMProveedor();
            var proveedor = (Entidades.Proveedor)dgvProveedores.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(frmABMProveedor.FormMode.delete, proveedor);
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void DgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNuevo.Enabled = true;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void InitializeDataGridView()
        {
            dgvProveedores.ColumnCount = 6;
            dgvProveedores.ColumnHeadersVisible = true;

            dgvProveedores.AutoGenerateColumns = false;

            dgvProveedores.Columns[0].Name = "Codigo Proveedor";
            dgvProveedores.Columns[0].DataPropertyName = "CodProveedor";

            dgvProveedores.Columns[1].Name = "Apellido";
            dgvProveedores.Columns[1].DataPropertyName = "Apellido";

            dgvProveedores.Columns[2].Name = "Nombre";
            dgvProveedores.Columns[2].DataPropertyName = "Nombre";

            dgvProveedores.Columns[3].Name = "Direccion";
            dgvProveedores.Columns[3].DataPropertyName = "Direccion";

            dgvProveedores.Columns[4].Name = "Telefono";
            dgvProveedores.Columns[4].DataPropertyName = "Telefono";

            dgvProveedores.Columns[5].Name = "Tiempo de entrega";
            dgvProveedores.Columns[5].DataPropertyName = "TiempoDeEntrega";
        }
    }
}
