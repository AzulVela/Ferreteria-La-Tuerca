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

namespace TpLaTuerca.Presentacion.Factura
{
    public partial class frmBusquedaProducto : Form
    {
        ProductoService productoService;
        public frmBusquedaProducto()
        {
            InitializeComponent();
            productoService = new ProductoService();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                var res = productoService.ObtenerProducto('%'+txtNombre.Text+'%');
                dgvBusqueda.DataSource = res;
            }

            else
                MessageBox.Show("Debe ingresar un nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
