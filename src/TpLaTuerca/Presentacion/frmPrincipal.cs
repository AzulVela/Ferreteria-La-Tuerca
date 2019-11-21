using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpLaTuerca.Presentación.Proveedor;
using TpLaTuerca.Presentacion.Productos;
using TpLaTuerca.Presentación.Cliente;
using TpLaTuerca.Presentación.Login;
using TpLaTuerca.Presentacion.Usuarios;
using TpLaTuerca.Presentacion.Factura;
using TpLaTuerca.Presentacion.Cuenta_Corriente;
using TpLaTuerca.Presentacion.Reportes;

namespace TpLaTuerca
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
           // frmLogin login = new frmLogin(this);
            //login.ShowDialog();
           
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmProductos producto = new frmProductos();
            producto.Show();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            frmProveedores proveedor = new frmProveedores();
           proveedor.Show();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            frmClientes cliente = new frmClientes();
            cliente.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rpta;
            rpta = MessageBox.Show("¿Seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rpta == DialogResult.No)
                e.Cancel = true;
        }

        private void DToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios usuario = new frmUsuarios();
            usuario.Show();
        }

        private void FacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFactura fac = new frmFactura();
            fac.ShowDialog();
        }

        private void BtnCuentaCorriente_Click(object sender, EventArgs e)
        {
            frmCuentaCorriente cuenta = new frmCuentaCorriente();
            cuenta.ShowDialog();
        }

        private void cuentaCorrienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteCtaCte rep = new ReporteCtaCte();
            rep.ShowDialog();
        }
    }
}
