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
using TpLaTuerca.AccesoDatos;
using TpLaTuerca.Entidades;


namespace TpLaTuerca.Presentacion.Cuenta_Corriente
{
    public partial class frmCuentaCorriente : Form
    {
        public CuentaCorrienteService oCuentaCorrienteService;

        public Cliente oClienteSeleccionado;

        frmListaClientes lista;

       // List<ResumenCuentCte> listaResumen;

        public frmCuentaCorriente()
        {
            this.CenterToParent();

            InitializeComponent();

            oCuentaCorrienteService = new CuentaCorrienteService();
            oClienteSeleccionado = new Cliente();

        //    listaResumen = new List<ResumenCuentCte>();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            var filtros = new Dictionary<string, object>();

                if (txtNombre.Text != string.Empty)
                {
                    filtros.Add("Nombre", txtNombre.Text + '%');
                }

                if (txtApellido.Text != string.Empty)
                {
                    filtros.Add("Apellido", txtApellido.Text + '%');
                }


            if (filtros.Count > 0)
            {
                lista = new frmListaClientes(this);
                lista.CargarClientes(filtros);
                lista.ShowDialog();

                List<ResumenCuentCte> listaResumen = oCuentaCorrienteService.ObtenerCuentaCliente(oClienteSeleccionado);

                txtTotal.Text = listaResumen.Sum(r => r.Importe).ToString();

                dgvCuentaCorriente.DataSource = listaResumen;

            }
            else
                MessageBox.Show("Se debe ingresar al menos un criterio de búsqueda", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            
        }

        private void FrmCuentaCorriente_Load(object sender, EventArgs e)
        {

        }

        internal void TomarCliente()
        {
            oClienteSeleccionado = lista.clienteSeleccionado;
            txtNombre.Text = oClienteSeleccionado.Nombre;
            txtApellido.Text = oClienteSeleccionado.Apellido;
        }

        private void DgvCuentaCorriente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnPagar.Enabled = true;
        }

        private void BtnPagar_Click(object sender, EventArgs e)
        {
            ResumenCuentCte resumen = (ResumenCuentCte)dgvCuentaCorriente.CurrentRow.DataBoundItem;
            bool pagado = oCuentaCorrienteService.UpdateEstado(resumen);
            
            if(pagado)
            {
                MessageBox.Show("La cuenta ha sido pagada,", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            BtnConsultar_Click(sender, e);
        }
    }
}
