using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLaTuerca.Entidades
{
    public class Proveedor
    {
        public int CodProveedor { set; get; }
        public string Apellido { set; get; }
        public string Nombre { set; get; }
        public string Direccion { set; get; }
        public string Telefono { set; get; }
        public int TiempoEntrega { set; get; }
        public string Estado { set; get; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
