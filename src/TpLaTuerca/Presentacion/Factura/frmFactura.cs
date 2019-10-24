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

        public frmFactura()
        {
            InitializeComponent();
            oTipoFacturaService = new TipoFacturaService();
            oClienteService = new ClienteService();
            oVendedorService = new VendedorService();
            oProductoService = new ProductoService();
            lstDetalles = new BindingList<DetalleFactura>();

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            LlenarCombo(cboTipoFactura,oTipoFacturaService.ObtenerTodos(),"nombre","codtipofactura");
            LlenarCombo(cboCliente, oClienteService.ObtenerTodos(), "Apellido", "codcliente");
            LlenarCombo(cboVendedor, oVendedorService.ObtenerTodos(), "Apellido","nrotipodoc");
            LlenarCombo(cboProducto, oProductoService.ObtenerTodos(new Dictionary<string, object>()), "Nombre", "codproducto");

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
    }
}
