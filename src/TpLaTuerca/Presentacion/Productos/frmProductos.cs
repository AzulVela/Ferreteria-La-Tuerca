using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpLaTuerca.Entidades;
using TpLaTuerca.LogicaNegocio;

namespace TpLaTuerca.Presentacion.Productos
{
    public partial class frmProductos : Form
    {
        private ProductoService oProductoService;
        private TipoUsoService oTipoUsoService;

        public frmProductos()
        {
            InitializeComponent();
            InitializeDataGridView();
            oProductoService = new ProductoService();
            oTipoUsoService = new TipoUsoService();
        }

        private void InitializeDataGridView()
        {
            dgvProductos.ColumnCount = 7;
            dgvProductos.ColumnHeadersVisible = true;

            dgvProductos.AutoGenerateColumns = false;

            dgvProductos.Columns[0].Name = "Codigo de Producto";
            dgvProductos.Columns[0].DataPropertyName = "CodProducto";

            dgvProductos.Columns[1].Name = "Nombre";
            dgvProductos.Columns[1].DataPropertyName = "Nombre";

            dgvProductos.Columns[2].Name = "Descripcion";
            dgvProductos.Columns[2].DataPropertyName = "Descripcion";

            dgvProductos.Columns[3].Name = "Tipo de medida";
            dgvProductos.Columns[3].DataPropertyName = "TipoMedida";

            dgvProductos.Columns[4].Name = "Precio";
            dgvProductos.Columns[4].DataPropertyName = "Precio";

            dgvProductos.Columns[5].Name = "Tipo de uso";
            dgvProductos.Columns[5].DataPropertyName = "TipoUso";

            dgvProductos.Columns[6].Name = "Proveedor";
            dgvProductos.Columns[6].DataPropertyName = "Proveedor";
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            LlenarCombo(cboTipoUso,oTipoUsoService.ObtenerTodos(),"Nombre","CodTipoUso");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                txtCodigo.Enabled = false;
                cboTipoUso.Enabled = false;
            }

            else
            {
                txtCodigo.Enabled = true;
                cboTipoUso.Enabled = true;
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            LLenarGrilla();
        }

        public void LLenarGrilla()
        {
            var filtros = new Dictionary<string, object>();

            if (!chkTodos.Checked)
            {
                if (txtCodigo.Text != string.Empty)
                    filtros.Add("codigo", txtCodigo.Text);

                if (cboTipoUso.Text != string.Empty)
                    filtros.Add("idTipoUso", cboTipoUso.SelectedValue);

                if (filtros.Count > 0)
                    dgvProductos.DataSource = oProductoService.ConsultarConFiltro(filtros);
                else
                    MessageBox.Show("Debe ingresarse al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
                dgvProductos.DataSource = oProductoService.ObtenerTodos(filtros);
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmDetalleProducto formulario = new frmDetalleProducto();
            formulario.ShowDialog();
            LLenarGrilla();

        }

        private void DgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            frmDetalleProducto frm = new frmDetalleProducto();
            var prod = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            frm.InicializarFormulario(frmDetalleProducto.FormMode.update, prod);
            frm.ShowDialog();
            LLenarGrilla();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            frmDetalleProducto frm = new frmDetalleProducto();
            var prod = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            frm.InicializarFormulario(frmDetalleProducto.FormMode.delete, prod);
            frm.ShowDialog();
            LLenarGrilla();
        }

        private void DgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }
    }
}
