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
            var filtros = new Dictionary<string, object>();

            if (!chkTodos.Checked)
            {
                if (txtNombre.Text != string.Empty)
                {
                    filtros.Add("usuario", txtNombre.Text);
                }

                if (filtros.Count > 0)
                    dgvUsuarios.DataSource = oUsuarioService.ConsultarConFiltros(filtros); //No implementado
                else
                    MessageBox.Show("Se debe ingresar al menos un criterio de búsqueda", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }

            else
                dgvUsuarios.DataSource = oUsuarioService.ObtenerTodos();
        }

        private void ChkTodos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmABMUsuarios formulario = new frmABMUsuarios();
            formulario.ShowDialog();

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
