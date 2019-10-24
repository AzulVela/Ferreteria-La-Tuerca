using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLaTuerca.AccesoDatos
{
    class TipoFacturaDao
    {
        internal object GetAll()
        {
            string sql = "select * from tipo_factura";
            return DataManager.GetInstance().ConsultaSQL(sql);
        }
    }
}
