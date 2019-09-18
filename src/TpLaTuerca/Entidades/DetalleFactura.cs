using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLaTuerca.Entidades
{
    public class DetalleFactura
    {
        public Factura Factura { set; get; }
        public Producto Producto { set; get; }
        public int Cantidad { set; get; }
        public float Precio { set; get; }
    }
}
