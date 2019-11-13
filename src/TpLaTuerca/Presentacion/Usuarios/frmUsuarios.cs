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
    public partial class frmUsuarios : Form
    {
        private UsuarioService oUsuarioService;

        public frmUsuarios()
        {
            oUsuarioService = new UsuarioService();
            InitializeComponent();
            InitializeDataGridView();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (!chkTodos.Checked)
            {
                if (txtNombre.Text != string.Empty)
                {
                    List<Usuario> usuario = new List<Usuario>();
                    usuario.Add(oUsuarioService.ObtenerUsuario(txtNombre.Text+'%'));
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
            formulario.InicializarFormulario(TpLaTuerca.Presentacion.Usuarios.frmABMUsuario.FormMode.update, usuario);
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            frmABMUsuario formulario = new frmABMUsuario();
            var usuario = (Usuario)dgvUsuarios.CurrentRow.DataBoundItem;
            formulario.InicializarFormulario(TpLaTuerca.Presentacion.Usuarios.frmABMUsuario.FormMode.delete, usuario);
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void ChkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked == true)
            {
                txtNombre.Enabled = false;
            }
            else
                txtNombre.Enabled = true;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            DataGridViewColumn ColumnaID = dgvUsuarios.Columns[0];
            ColumnaID.Visible = false;
        }

        private void DgvUsuarios_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void InitializeDataGridView()
        {
            dgvUsuarios.ColumnCount = 4;
            dgvUsuarios.ColumnHeadersVisible = true;

            dgvUsuarios.AutoGenerateColumns = false;

            dgvUsuarios.Columns[0].Name = "Id Usuario";
            dgvUsuarios.Columns[0].DataPropertyName = "idUsuario";

            dgvUsuarios.Columns[1].Name = "Nombre de usuario";
            dgvUsuarios.Columns[1].DataPropertyName = "nombreUsuario";

            dgvUsuarios.Columns[2].Name = "Email";
            dgvUsuarios.Columns[2].DataPropertyName = "email";

            dgvUsuarios.Columns[3].Name = "Password";
            dgvUsuarios.Columns[3].DataPropertyName = "password";
        }
    }
}
