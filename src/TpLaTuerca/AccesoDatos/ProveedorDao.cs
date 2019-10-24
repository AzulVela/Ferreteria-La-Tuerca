using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLaTuerca.AccesoDatos
{
    class ProveedorDao
    {
        internal object GetAll()
        {
            string sql = "select * from proveedor where habilitado = 1";
            return DataManager.GetInstance().ConsultaSQL(sql);
        }
    }
}
