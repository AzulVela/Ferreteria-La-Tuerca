using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLaTuerca.Entidades
{
    public class Cliente
    {
        public int CodCliente { set; get; }
        public string Apellido { set; get; }
        public string Nombre { set; get; }
        public string Telefono { set; get; }
        public string CUIT { set; get; }
    }
}
