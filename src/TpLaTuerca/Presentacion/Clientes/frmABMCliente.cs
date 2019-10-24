using TpLaTuerca.Entidades;
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

namespace TpLaTuerca.Presentación.Clientes
{
    public partial class frmABMCliente : Form
    {
        private FormMode formMode = FormMode.insert;
        private readonly ClienteService oClienteService;
        private Entidades.Cliente oClienteSelected;
        


        public frmABMCliente()
        {
            InitializeComponent();
            oClienteService = new ClienteService();
        }

        public enum FormMode
        {
            insert,
            update,
            delete
        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmABMCliente_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            switch(formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo cliente";
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar cliente";
                        MostrarDatos();
                        txtApellido.Enabled = true;
                        txtNombre.Enabled = true;
                        txtTelefono.Enabled = true;
                        txtCuit.Enabled = true;
                        break;

                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar cliente";
                        txtApellido.Enabled = false;
                        txtNombre.Enabled = false;
                        txtTelefono.Enabled = false;
                        txtCuit.Enabled = false;
                        break;

                    }

            }
        }

        public void InicializarFormulario(FormMode op, Entidades.Cliente ClienteSelected)
        {
            formMode = op;
            oClienteSelected = ClienteSelected;
        }

        private void MostrarDatos()
        {
            if (oClienteSelected != null)
            {
                txtNombre.Text = oClienteSelected.Nombre;
                txtApellido.Text = oClienteSelected.Apellido;
                txtTelefono.Text = oClienteSelected.Telefono;
                txtCuit.Text = oClienteSelected.CUIT;

            }
        }

        private void txtCuit_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            switch(formMode)
            {
                case FormMode.insert:
                    {
                        if (ExisteCliente() == false)
                        {
                            if (ValidarCampos())
                            {
                                var oCliente = new Entidades.Cliente();
                                oCliente.Nombre = txtNombre.Text;
                                oCliente.Apellido = txtApellido.Text;
                                oCliente.Telefono = txtTelefono.Text;
                                oCliente.CUIT = txtCuit.Text;

                                if (oClienteService.CrearCliente(oCliente))
                                {
                                    MessageBox.Show("Usuario insertado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }

                            }

                        }

                        else
                            MessageBox.Show("CUIT existente. Usted ya se encuentra registrado","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                case FormMode.update:
                    {
                            if (ValidarCampos())
                            {
                                oClienteSelected.Nombre = txtNombre.Text;
                                oClienteSelected.Apellido = txtApellido.Text;
                                oClienteSelected.Telefono = txtTelefono.Text;
                                oClienteSelected.CUIT = txtCuit.Text;

                                if (oClienteService.ActualizarCliente(oClienteSelected))
                                {
                                    MessageBox.Show("Cliente actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Dispose();
                                }

                                else
                                    MessageBox.Show("Error al actualizar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                    }

                case FormMode.delete:
                    {
                        if (MessageBox.Show("¿Seguro que desea deshabilitar al cliente seleccionado?","Aviso",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (oClienteService.ModificarEstadoCliente(oClienteSelected))
                            {
                                MessageBox.Show("Cliente dehabilitado con éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al deshabilitar el cliente","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                txtApellido.BackColor = Color.White;

            if (txtCuit.Text == string.Empty)
            {
                txtCuit.BackColor = Color.Red;
                txtCuit.Focus();
                return false;
            }

            else
                txtCuit.BackColor = Color.White;

            if (txtTelefono.Text == string.Empty)
            {
                txtTelefono.BackColor = Color.Red;
                txtTelefono.Focus();
                return false;
            }

            else
                txtTelefono.BackColor = Color.White;

            return true;
        }

        private bool ExisteCliente()
        {
            return oClienteService.ObtenerCliente(txtCuit.Text) != null;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
