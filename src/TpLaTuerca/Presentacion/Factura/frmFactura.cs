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

namespace TpLaTuerca.Presentacion.Factura
{
    public partial class frmFactura : Form
    {
        private readonly BindingList<DetalleFactura> lstDetalles;
        private readonly TipoFacturaService oTipoFacturaService;
        private readonly ClienteService oClienteService;
        private readonly VendedorService oVendedorService;
        private readonly ProductoService oProductoService;
        private readonly FacturaService oFacturaService;

        public frmFactura()
        {
            InitializeComponent();

            dgvDetalle.AutoGenerateColumns = false;
            oTipoFacturaService = new TipoFacturaService();
            oClienteService = new ClienteService();
            oVendedorService = new VendedorService();
            oProductoService = new ProductoService();
            oFacturaService = new FacturaService();
            lstDetalles = new BindingList<DetalleFactura>();

        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            LlenarCombo(cboTipoFactura,oTipoFacturaService.ObtenerTodos(),"nombre","codtipofactura");
            LlenarCombo(cboCliente, oClienteService.ObtenerTodos(), "Apellido", "codcliente");
            LlenarCombo(cboVendedor, oVendedorService.ObtenerTodos(), "Apellido","NroDoc");
            LlenarCombo(cboProducto, oProductoService.ObtenerTodos(new Dictionary<string, object>()), "Nombre", "codproducto");
            txtPrecio.ReadOnly = true;
            txtTotal.ReadOnly = true;
            txtImporte.ReadOnly = true;
            dgvDetalle.DataSource = lstDetalles;

        }

        private void IniciaizarDetalle()
        {
            cboProducto.SelectedIndex = -1;
            txtCantidad.Text = "";
            txtPrecio.Text = 0.ToString("C");
            txtImporte.Text = 0.ToString("C");
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void BtnAgregarItem_Click(object sender, EventArgs e)
        {
            int cant = 0;
            int.TryParse(txtCantidad.Text, out cant);

            var producto = (Producto)cboProducto.SelectedItem;
            lstDetalles.Add(new DetalleFactura()
            {
                Producto = producto,
                Cantidad = cant,
                Precio = producto.Precio,
                Importe = cant * producto.Precio
                

            });

            var total = lstDetalles.Sum(p => p.Importe);
            txtTotal.Text = total.ToString("C");

            IniciaizarDetalle();

            dgvDetalle.DataSource = lstDetalles;
        }

        

        private void CboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex != -1)
            {
                Producto producto = (Producto)cboProducto.SelectedItem;
                txtPrecio.Text = producto.Precio.ToString();
                txtCantidad.Enabled = true;
                int cant = 0;
                int.TryParse(txtCantidad.Text, out cant);
                txtImporte.Text = (producto.Precio * cant).ToString("C");
                btnAgregarItem.Enabled = true;
            }

            else
            {
                btnAgregarItem.Enabled = false;
                txtCantidad.Enabled = false;
                txtCantidad.Text = "";
                txtPrecio.Text = "";
                txtImporte.Text = "";
            }
        }

        private void TxtCantidad_Leave(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex != -1)
            {
                int cant = 0;
                int.TryParse(txtCantidad.Text, out cant);
                var prod = (Producto)cboProducto.SelectedItem;
                txtImporte.Text = (cant * prod.Precio).ToString("C");
            }
        }

        private void BtnQuitarItem_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow != null)
            {
                var selectedDetalle = (DetalleFactura)dgvDetalle.CurrentRow.DataBoundItem;
                lstDetalles.Remove(selectedDetalle);

                var total = lstDetalles.Sum(p => p.Importe);
                txtTotal.Text = total.ToString("C");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //try
            //{
                var factura = new Entidades.Factura
                {
                    FechaFactura = dtpFecha.Value,
                    DetalleFactura = lstDetalles,
                    Cliente = (Cliente)cboCliente.SelectedItem,
                    TipoFactura = (TipoFactura)cboTipoFactura.SelectedItem,
                    Vendedor = (Vendedor)cboVendedor.SelectedItem
                };

                if (oFacturaService.ValidarDatos(factura))
                {
                    oFacturaService.Crear(factura);

                    MessageBox.Show(string.Concat("La factura nro: ", factura.NroFactura, " se generó correctamente."), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnAgregarItem.Enabled = false;
                    cboTipoFactura.SelectedIndex = -1;
                    cboCliente.SelectedIndex = -1;
                    cboVendedor.SelectedIndex = -1;
                    cboProducto.SelectedIndex = -1;

                    dgvDetalle.DataSource = null;
                }
            //}

            //catch (Exception ex)
           // {
               // MessageBox.Show("Error al registrar la factura " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void DgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
