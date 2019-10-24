using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLaTuerca.AccesoDatos
{
    class VendedorDao
    {
        internal object GetAll()
        {
            string sql = "select * from vendedor";
            return DataManager.GetInstance().ConsultaSQL(sql);
        }
    }
}
