using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLaTuerca.Entidades
{
    public class Estructura
    {
        public Producto ProductoSuperior { set; get; }
        public Producto ProductoInferior { set; get; }
        public int Cantidad { set; get; }
    }
}
