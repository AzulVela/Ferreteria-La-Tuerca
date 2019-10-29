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
using TpLaTuerca.Entidades;

namespace TpLaTuerca.Presentación.Proveedor
{
    public partial class frmABMProveedor : Form
    {
        private FormMode formMode = FormMode.insert;
        private readonly ProveedorService oProveedorService;
        private Entidades.Proveedor oProveedorSelected;

        public frmABMProveedor()
        {
            InitializeComponent();
            oProveedorService = new ProveedorService();
        }

        public enum FormMode
        {
            insert,
            update,
            delete
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void MostrarDatos()
        {
            if (oProveedorSelected != null)
            {
                txtNombre.Text = oProveedorSelected.Nombre;
                txtApellido.Text = oProveedorSelected.Apellido;
                txtDireccion.Text = oProveedorSelected.Direccion;
                txtTelefono.Text = oProveedorSelected.Telefono;
                //txtTiempoEntrega.Text = oProveedorSelected.TiempoEntrega;

            }
        }

        internal void InicializarFormulario(FormMode op, Entidades.Proveedor ProveedorSelected)
        {
            formMode = op;
            oProveedorSelected = ProveedorSelected;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (ExisteProveedor() == false)
                        {
                            if (ValidarCampos())
                            {
                                var oProveedor = new Entidades.Proveedor();
                                oProveedor.Nombre = txtNombre.Text;
                                oProveedor.Apellido = txtApellido.Text;
                                oProveedor.Direccion = txtDireccion.Text;
                                oProveedor.Telefono = txtTelefono.Text;
                                //oProveedor.TiempoEntrega = txtTiempoEntrega.Text;

                                if (oProveedorService.CrearProveedor(oProveedor))
                                {
                                    MessageBox.Show("Proveedor insertado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }

                            }

                        }

                        else
                            MessageBox.Show("Proveedor existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oProveedorSelected.Nombre = txtNombre.Text;
                            oProveedorSelected.Apellido = txtApellido.Text;
                            oProveedorSelected.Direccion = txtDireccion.Text;
                            oProveedorSelected.Telefono = txtTelefono.Text;
                            //oProveedorSelected.TiempoEntrega = txtTiempoEntrega.Text;

                            if (oProveedorService.ActualizarProveedor(oProveedorSelected))
                            {
                                MessageBox.Show("Proveedor actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }

                            else
                                MessageBox.Show("Error al actualizar el proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }

                case FormMode.delete:
                    {
                        if (MessageBox.Show("¿Seguro que desea deshabilitar al proveedor seleccionado?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (oProveedorService.ModificarEstadoProveedor(oProveedorSelected))
                            {
                                MessageBox.Show("Proveedor dehabilitado con éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al deshabilitar el proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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

            if (txtApellido.Text == string.Empty)
            {
                txtApellido.BackColor = Color.Red;
                txtApellido.Focus();
                return false;
            }
            else
                txtNombre.BackColor = Color.White;

            return true;
        }

        private bool ExisteProveedor()
        {
            return oProveedorService.ObtenerProveedor(oProveedorSelected) != null;
        }

        private void FrmABMProveedor_Load_1(object sender, EventArgs e)
        {
            this.CenterToParent();
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo Proveedor";
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar Proveedor";
                        MessageBox.Show("Entra");
                        MostrarDatos();
                        txtNombre.Enabled = true;
                        txtApellido.Enabled = true;
                        txtDireccion.Enabled = true;
                        txtTelefono.Enabled = true;
                        txtTiempoEntrega.Enabled = true;
                        break;

                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Proveedor";
                        txtNombre.Enabled = false;
                        txtApellido.Enabled = false;
                        txtDireccion.Enabled = false;
                        txtTelefono.Enabled = false;
                        txtTiempoEntrega.Enabled = false;
                        break;

                    }

            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtApellido_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
