using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLaTuerca.Entidades
{
    public class CuentaCorriente
    {
        public int IdCuentaCorriente { set; get; }
        public Factura Factura { set; get; }
        public Cliente Cliente { set; get; }
    }
}
