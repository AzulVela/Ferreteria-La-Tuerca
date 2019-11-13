using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLaTuerca.Entidades
{
    public class ResumenCuentCte
    {
        public int NroFactura { get; set; }
        public int CodTipoFactura { get; set; }
        public DateTime Fecha { get; set; }
        public Double Importe { get; set; }
    }
}
