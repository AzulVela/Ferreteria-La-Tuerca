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
        frmListaProductos lista;
        CuentaCorrienteService oCuentaCorrienteService;

        Producto productoSeleccionado;

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

            productoSeleccionado = new Producto();
            oCuentaCorrienteService = new CuentaCorrienteService();
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            LlenarCombo(cboTipoFactura,oTipoFacturaService.ObtenerTodos(),"nombre","codtipofactura");
            LlenarCombo(cboCliente, oClienteService.ObtenerTodos(), "Apellido", "codcliente");
            LlenarCombo(cboVendedor, oVendedorService.ObtenerTodos(), "Apellido","NroDoc");
           // LlenarCombo(cboProducto, oProductoService.ObtenerTodos(new Dictionary<string, object>()), "Nombre", "codproducto");
            txtPrecio.ReadOnly = true;
            txtTotal.ReadOnly = true;
            txtImporte.ReadOnly = true;
            dgvDetalle.DataSource = lstDetalles;

        }

        private void IniciaizarDetalle()
        {
          //  cboProducto.SelectedIndex = -1;
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

            lstDetalles.Add(new DetalleFactura()
            {
                Producto = productoSeleccionado,
                Cantidad = cant,
                Precio = productoSeleccionado.Precio,
                Importe = cant * productoSeleccionado.Precio
            });

            var total = lstDetalles.Sum(p => p.Importe);
            txtTotal.Text = total.ToString("C");

            IniciaizarDetalle();

            dgvDetalle.DataSource = lstDetalles;
        }

        

        private void CboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboProducto.SelectedIndex != -1)
            //{
            //    Producto producto = (Producto)cboProducto.SelectedItem;
            //    txtPrecio.Text = producto.Precio.ToString();
            //    txtCantidad.Enabled = true;
            //    int cant = 0;
            //    int.TryParse(txtCantidad.Text, out cant);
            //    txtImporte.Text = (producto.Precio * cant).ToString("C");
            //    btnAgregarItem.Enabled = true;
            //}

            //else
            //{
            //    btnAgregarItem.Enabled = false;
            //    txtCantidad.Enabled = false;
            //    txtCantidad.Text = "";
            //    txtPrecio.Text = "";
            //    txtImporte.Text = "";
            //}
        }

        internal void TomaProducto()
        {
            productoSeleccionado = lista.producto_;

            txtProducto.Text = productoSeleccionado.Nombre;
            txtPrecio.Text = productoSeleccionado.Precio.ToString();
            txtCantidad.Enabled = true;
            int cant = 0;
            int.TryParse(txtCantidad.Text, out cant);
            txtImporte.Text = (productoSeleccionado.Precio * cant).ToString("C");
            btnAgregarItem.Enabled = true;
        }

        private void TxtCantidad_Leave(object sender, EventArgs e)
        {
            //if (cboProducto.SelectedIndex != -1)
            //{
            //    int cant = 0;
            //    int.TryParse(txtCantidad.Text, out cant);
            //    var prod = (Producto)cboProducto.SelectedItem;
            //    txtImporte.Text = (cant * prod.Precio).ToString("C");
            //}
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
                    if (rdbCorriente.Checked)
                    {
                        //Con fiado
                        oFacturaService.Crear(factura, true);
                    }
                    else
                        oFacturaService.Crear(factura, false);

                    string nroFactura = oFacturaService.BuscarAlMayor();

                    MessageBox.Show(string.Concat("La factura nro: ", nroFactura, " se generó correctamente."), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnAgregarItem.Enabled = false;
                    cboTipoFactura.SelectedIndex = -1;
                    cboCliente.SelectedIndex = -1;
                    cboVendedor.SelectedIndex = -1;
                   // cboProducto.SelectedIndex = -1;

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

<<<<<<< HEAD
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            frmBusquedaProducto frm = new frmBusquedaProducto();
            frm.ShowDialog();
=======
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TxtProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txtProducto.Text != string.Empty)
                {
                    string nombre = txtProducto.Text;

                    lista = new frmListaProductos(this);

                    lista.CargarProductos(nombre);

                    lista.ShowDialog();
                }
            }
>>>>>>> 339bf3fefbe84d461ccb2f30ca48f9291dc7131f
        }
    }
}
