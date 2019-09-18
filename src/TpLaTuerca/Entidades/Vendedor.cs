using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLaTuerca.Entidades
{
    public class Vendedor
    {
        public TipoDoc TipoDoc { set; get; }
        public int NroDoc { set; get; }
        public DateTime FechaIngreso { set; get; }
        public DateTime FechaNacimiento { set; get; }
        public string Apellido { set; get; }
        public string Nombre { set; get; }
        public string Telefono { set; get; }
    }
}
