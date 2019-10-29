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
        private Producto oProductoSelected;

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

                case FormMode.update:
                    {
                        this.Text = "Actualizar producto";
                        MostrarDatos();

                        break;
                    }

                case FormMode.delete:
                    {
                        this.Text = "Deshabilitar producto";
                        MostrarDatos();
                        txtNombre.Enabled = false;
                        txtPrecio.Enabled = false;
                        txtDescripcion.Enabled = false;
                        cboProveedor.Enabled = false;
                        cboTipoMedida.Enabled = false;
                        cboTipoUso.Enabled = false;

                        break;
                    }
            }




        }

        private void MostrarDatos()
        {
            txtNombre.Text = oProductoSelected.Nombre;
            txtPrecio.Text = oProductoSelected.Precio.ToString();
            txtDescripcion.Text = oProductoSelected.Descripcion;
            cboTipoUso.Text = oProductoSelected.TipoUso.Nombre;
            cboTipoMedida.Text = oProductoSelected.TipoMedida.Nombre;
            cboProveedor.Text = oProductoSelected.Proveedor.Nombre;
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

                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oProductoSelected.Nombre = txtNombre.Text;
                            oProductoSelected.Precio = float.Parse(txtPrecio.Text);
                            oProductoSelected.Descripcion = txtDescripcion.Text;
                            oProductoSelected.Proveedor = new Proveedor();
                            oProductoSelected.Proveedor.CodProveedor = (int)cboProveedor.SelectedValue;
                            oProductoSelected.TipoMedida = new TipoMedida();
                            oProductoSelected.TipoMedida.CodTipoMedida = (int)cboTipoMedida.SelectedValue;
                            oProductoSelected.TipoUso = new TipoUso();
                            oProductoSelected.TipoUso.CodTipoUso = (int)cboTipoUso.SelectedValue;

                            if (oProductoService.ActualizarProducto(oProductoSelected))
                            {
                                MessageBox.Show("Producto actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                            }

                            else
                                MessageBox.Show("Error al actualizar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }
                case FormMode.delete:
                    {

                        if (MessageBox.Show("¿Seguro desea deshabilitar el producto seleccionado?","Aviso",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            if (oProductoService.DeshabilitarProducto(oProductoSelected))
                            {
                                MessageBox.Show("Producto deshabilitado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            else
                                MessageBox.Show("Error al deshabilitar producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }
            }

        }

        private bool ValidarCampos()
        {
            if (txtNombre.Text.Length > 20)
            {
                MessageBox.Show("Exceso de caracteres, ingrese un nombre válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.BackColor = Color.Red;
                txtNombre.Text = "";
                return false;
            }

            else
                txtNombre.BackColor = Color.White;

            if (txtDescripcion.Text.Length > 20)
            {
                MessageBox.Show("Exceso de caracteres, ingrese una descripción válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.BackColor = Color.Red;
                txtDescripcion.Text = "";
            }

            else
                txtDescripcion.BackColor = Color.White;

            if (txtPrecio.Text.Length > 6)
            {
                MessageBox.Show("Exceso de caracteres, ingrese un precio válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.BackColor = Color.Red;
                txtPrecio.Text = "";
            }

            else
                txtPrecio.BackColor = Color.White;
        

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

        public void InicializarFormulario(FormMode op, Producto usuarioSelected)
        {
            formMode = op;
            oProductoSelected = usuarioSelected;
        }

        private void CboTipoMedida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void LblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}
