using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLaTuerca.Entidades
{
    public class Producto
    {
        public int CodProducto { set; get; }
        public string Nombre { set; get; }
        public string Descripcion { set; get; }
        public TipoMedida TipoMedida { set; get; }
        public float Precio { set; get; }
        public TipoUso TipoUso { set; get; }
        public Proveedor Proveedor { set; get; }
    }
}
