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

namespace TpLaTuerca.Presentacion.Usuarios
{
    public partial class frmABMUsuario : Form
    {
        private FormMode formMode = FormMode.insert;

        private Usuario oUsuarioSelected;

        private UsuarioService oUsuarioService ;

        public frmABMUsuario()
        {
            InitializeComponent();
            oUsuarioService = new UsuarioService();
        }

        public enum FormMode
        {
            insert,
            update,
            delete
        }

        private void FrmABMUsuario_Load(object sender, EventArgs e)
        {
            switch(formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo Usuario";
                        break;
                    }
                case FormMode.update:
                    {
                        this.Text = "Actualizar Usuario";
                        MostrarDatos();

                        txtNombre.Enabled = true;
                        txtPassword.Enabled = true;
                        txtEmail.Enabled = true;
                        txtConfirmarPass.Enabled = true;

                        break;
                    }
                case FormMode.delete:
                    {
                        this.Text = "Deshabilitar Usuario";
                        MostrarDatos();

                        txtNombre.Enabled = false;
                        txtPassword.Enabled = false;
                        txtEmail.Enabled = false;
                        txtConfirmarPass.Enabled = false;

                        break;
                    }
            }
        }

        private void MostrarDatos()
        {
            if (oUsuarioSelected != null)
            {
                txtNombre.Text = oUsuarioSelected.NombreUsuario;
                txtPassword.Text = oUsuarioSelected.Password;
                txtEmail.Text = oUsuarioSelected.Email;
                txtConfirmarPass.Text = oUsuarioSelected.Password;
            }
        }

        internal void InicializarFormulario(FormMode opc, Usuario usuario)
        {
            formMode = opc;
            oUsuarioSelected = usuario;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            switch(formMode)
            {
                case FormMode.insert:
                    {
                        if (ExisteUsuario() == false)
                        {
                            if (ValidarCampos())
                            {
                                var oUsuario = new Usuario();

                                oUsuario.NombreUsuario = txtNombre.Text;
                                oUsuario.Password = txtPassword.Text;
                                oUsuario.Email = txtEmail.Text;

                                if (oUsuarioService.CrearUsuario(oUsuario))
                                {
                                    MessageBox.Show("Usuario insertado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                            else
                                MessageBox.Show("Ya existe un usuario con ese nombre", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    }

                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oUsuarioSelected.NombreUsuario = txtNombre.Text;
                            oUsuarioSelected.Password = txtPassword.Text;
                            oUsuarioSelected.Email = txtEmail.Text;

                            if (oUsuarioService.ActualizarUsuario(oUsuarioSelected))
                            {
                                MessageBox.Show("Usuario Actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al actualizar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        break;
                    }

                case FormMode.delete:
                    {
                        var rta = MessageBox.Show("¿Seguro que desea deshabilitar al usuario seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta == DialogResult.Yes)
                        {
                            if (oUsuarioService.ModificarEstado(oUsuarioSelected))
                            {
                                MessageBox.Show("Usuario dehabilitado con éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al deshabilitar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }
            }
        }

        private bool ExisteUsuario()
        {
            return oUsuarioService.ObtenerUsuario(txtNombre.Text) != null;
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

            if (txtPassword.Text == string.Empty)
            {
                txtPassword.BackColor = Color.Red;
                txtPassword.Focus();
                return false;
            }
            else
                txtPassword.BackColor = Color.White;

            if (txtConfirmarPass.Text == string.Empty)
            {
                txtConfirmarPass.BackColor = Color.Red;
                txtConfirmarPass.Focus();
                return false;
            }
            else
                txtConfirmarPass.BackColor = Color.White;

            if (txtConfirmarPass.Text != txtPassword.Text)
            {
                txtConfirmarPass.BackColor = Color.Red;
                txtPassword.BackColor = Color.Red;
                txtConfirmarPass.Focus();
                return false;
            }
            else
            {
                txtConfirmarPass.BackColor = Color.White;
                txtPassword.BackColor = Color.White;
            }

            return true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
