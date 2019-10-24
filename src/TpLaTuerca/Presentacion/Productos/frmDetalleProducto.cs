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
    public partial class frmDetalleProducto : Form
    {
        private ProveedorService oProveedorService;
        private TipoUsoService oTipoUsoService;
        private TipoMedidaService oTipoMedidaService;
        private ProductoService oProductoService;
        private FormMode formMode = FormMode.insert;


        public frmDetalleProducto()
        {
            oProveedorService = new ProveedorService();
            oTipoUsoService = new TipoUsoService();
            oTipoMedidaService = new TipoMedidaService();
            oProductoService = new ProductoService();

            InitializeComponent();
        }

        public enum FormMode
        {
            insert,
            update,
            delete
        }

        private void CboProveedores_Click(object sender, EventArgs e)
        {

        }

        private void FrmDetalleProducto_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            LlenarCombo(cboProveedor, oProveedorService.ObtenerTodos(), "Apellido", "codproveedor");
            LlenarCombo(cboTipoMedida, oTipoMedidaService.ObtenerTodos(), "Nombre", "codtipomedida");
            LlenarCombo(cboTipoUso, oTipoUsoService.ObtenerTodos(), "Nombre", "codtipouso");

            switch(formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo producto";
                        break;
                    }
            }




        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            switch(formMode)
            {
                case FormMode.insert:
                {
                    if (ExisteProducto() == false)
                    {
                        if (ValidarCampos())
                        {
                            var oProducto = new Producto();
                            oProducto.Nombre = txtNombre.Text;
                            oProducto.Precio = float.Parse(txtPrecio.Text);
                            oProducto.Descripcion = txtDescripcion.Text;
                            oProducto.Proveedor = new Proveedor();
                            oProducto.Proveedor.CodProveedor = (int)cboProveedor.SelectedValue;
                            oProducto.TipoMedida = new TipoMedida();
                            oProducto.TipoMedida.CodTipoMedida = (int)cboTipoMedida.SelectedValue;
                            oProducto.TipoUso = new TipoUso();
                            oProducto.TipoUso.CodTipoUso = (int)cboTipoUso.SelectedValue;

                                if (oProductoService.CrearProducto(oProducto))
                                {
                                    MessageBox.Show("Producto insertado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }

                                else
                                    MessageBox.Show("Error al insertar producto","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Ya existe un producto con el mismo nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

        }

        private bool ValidarCampos()
        {
            if (txtNombre.Text == string.Empty)
            {
                txtNombre.BackColor = Color.Red;
                txtNombre.Focus();
                return false;
            }

            else
                txtNombre.BackColor = Color.White;

            if (txtPrecio.Text == string.Empty)
            {
                txtPrecio.BackColor = Color.Red;
                txtPrecio.Focus();
                return false;
            }

            else
                txtPrecio.BackColor = Color.White;

            if (cboTipoUso.SelectedIndex == -1)
            {
                cboTipoUso.BackColor = Color.Red;
                cboTipoUso.Focus();
                return false;
            }

            else
                cboTipoUso.BackColor = Color.White;

            if (cboTipoMedida.SelectedIndex == -1)
            {
                cboTipoMedida.BackColor = Color.Red;
                cboTipoMedida.Focus();
                return false;
            }

            else
                cboTipoMedida.BackColor = Color.White;

            if (cboProveedor.SelectedIndex == -1)
            {
                cboProveedor.BackColor = Color.Red;
                cboProveedor.Focus();
                return false;
            }

            else
                cboProveedor.BackColor = Color.White;

            return true;
        }

        private bool ExisteProducto()
        {
            return oProductoService.ObtenerProducto(txtNombre.Text) != null;
        }

        private void CboTipoMedida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
