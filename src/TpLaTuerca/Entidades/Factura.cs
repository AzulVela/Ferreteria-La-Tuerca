using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLaTuerca.Entidades
{
    public class Factura
    {
        public int NroFactura { set; get; }
        public TipoFactura TipoFactura { set; get; }
        public Cliente Cliente { set; get; }
        public Vendedor Vendedor { set; get; }
        public IList<DetalleFactura> DetalleFactura { set; get; }
        public DateTime FechaFactura { set; get; }
    }
}
