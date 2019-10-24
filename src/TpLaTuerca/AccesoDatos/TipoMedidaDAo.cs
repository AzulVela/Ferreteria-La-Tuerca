using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLaTuerca.AccesoDatos
{
    class TipoMedidaDao
    {
        internal object GetAll()
        {
            string sql = "select * from tipo_medida";
            return DataManager.GetInstance().ConsultaSQL(sql);
        }
    }
}
