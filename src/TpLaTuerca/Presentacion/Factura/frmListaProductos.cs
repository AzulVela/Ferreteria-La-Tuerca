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
using TpLaTuerca.Entidades;

namespace TpLaTuerca.Presentacion.Factura
{
    public partial class frmListaProductos : Form
    {
        ProductoService oProductoService;
        public Producto producto_ { get; set; }
        frmFactura factura_;

        public frmListaProductos(frmFactura factura)
        {
            oProductoService = new ProductoService();
            InitializeComponent();
            InitializeDataGridView();
            factura_ = factura;
            producto_ = new Producto();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmListaProductos_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            DataGridViewColumn ColumnaDescrip = dgvListaProductos.Columns[2];
            ColumnaDescrip.Visible = false;
            DataGridViewColumn ColumnaTipoMed = dgvListaProductos.Columns[3];
            ColumnaTipoMed.Visible = false;
            DataGridViewColumn ColumnaTipoUso = dgvListaProductos.Columns[5];
            ColumnaTipoUso.Visible = false;
            DataGridViewColumn ColumnaProve = dgvListaProductos.Columns[6];
            ColumnaProve.Visible = false;
        }

        internal void CargarProductos(string nombre)
        {
            var filtros = new Dictionary<string, object>();
            filtros.Add("Nombre", nombre + '%');

            dgvListaProductos.DataSource = oProductoService.ConsultarConFiltro(filtros);
        }

        private void DgvListaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InitializeDataGridView()
        {
            dgvListaProductos.ColumnCount = 7;
            dgvListaProductos.ColumnHeadersVisible = true;

            dgvListaProductos.AutoGenerateColumns = false;

            dgvListaProductos.Columns[0].Name = "Codigo de Producto";
            dgvListaProductos.Columns[0].DataPropertyName = "CodProducto";

            dgvListaProductos.Columns[1].Name = "Nombre";
            dgvListaProductos.Columns[1].DataPropertyName = "Nombre";

            dgvListaProductos.Columns[2].Name = "Descripcion";
            dgvListaProductos.Columns[2].DataPropertyName = "Descripcion";

            dgvListaProductos.Columns[3].Name = "Tipo de medida";
            dgvListaProductos.Columns[3].DataPropertyName = "TipoMedida";

            dgvListaProductos.Columns[4].Name = "Precio";
            dgvListaProductos.Columns[4].DataPropertyName = "Precio";

            dgvListaProductos.Columns[5].Name = "Tipo de uso";
            dgvListaProductos.Columns[5].DataPropertyName = "TipoUso";

            dgvListaProductos.Columns[6].Name = "Proveedor";
            dgvListaProductos.Columns[6].DataPropertyName = "Proveedor";
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            producto_ = (Entidades.Producto)dgvListaProductos.CurrentRow.DataBoundItem;
            factura_.TomaProducto();
            this.Close();
        }
    }
    
}
