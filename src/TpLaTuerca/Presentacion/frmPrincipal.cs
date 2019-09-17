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
            frmLogin login = new frmLogin();
            login.ShowDialog();
           
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmClientes cliente = new frmClientes();
            cliente.Show();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            frmProveedores proveedor = new frmProveedores();
           proveedor.Show();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            frmProductos producto = new frmProductos();
            producto.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
