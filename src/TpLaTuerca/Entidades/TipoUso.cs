using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLaTuerca.Entidades
{
    public class TipoUso
    {
        public int CodTipoUso { set; get; }
        public string Nombre { set; get; }
        public string Descripcion { set; get; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
