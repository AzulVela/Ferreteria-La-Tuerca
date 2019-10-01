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
using static TpLaTuerca.Presentacion.Usuarios.frmABMUsuario;

namespace TpLaTuerca.Presentacion.Usuarios
{
    public partial class frmUsuarios : Form
    {
        private UsuarioService oUsuarioService;

        public frmUsuarios()
        {
            oUsuarioService = new UsuarioService();
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (!chkTodos.Checked)
            {
                if (txtNombre.Text != string.Empty)
                {
                    List<Usuario> usuario = new List<Usuario>();
                    usuario.Add(oUsuarioService.ObtenerUsuario(txtNombre.Text));
                    dgvUsuarios.DataSource = usuario;
                }

                else
                    MessageBox.Show("Se debe ingresar al menos un criterio de búsqueda", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
                dgvUsuarios.DataSource = oUsuarioService.ObtenerTodos();
        }


        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmABMUsuario formulario = new frmABMUsuario();
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            frmABMUsuario formulario = new frmABMUsuario();
            var usuario = (Usuario)dgvUsuarios.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(FormMode.update, usuario);
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            frmABMUsuario formulario = new frmABMUsuario();
            var usuario = (Usuario)dgvUsuarios.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(FormMode.delete, usuario);
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

    }
}
