using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.Entidades;

namespace TpLaTuerca.AccesoDatos
{
    class TipoUsoDao
    {
        internal object GetAll()
        {
            List<TipoUso> lst = new List<TipoUso>();

            var sql = "select * from tipo_uso";
            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(sql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                lst.Add(ObjectMapping(row));
            }
            return lst;
        }

        private TipoUso ObjectMapping(DataRow row)
        {
            TipoUso oTipoUso = new TipoUso()
            {
                CodTipoUso = Convert.ToInt32(row["CodTipoUso"].ToString()),
                Nombre = row["Nombre"].ToString(),
                Descripcion = row["Descripcion"].ToString()
            };
            return oTipoUso;

        }
    }
}
