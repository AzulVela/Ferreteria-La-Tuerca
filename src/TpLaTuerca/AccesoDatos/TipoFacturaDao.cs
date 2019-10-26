using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.Entidades;

namespace TpLaTuerca.AccesoDatos
{
    class TipoFacturaDao
    {
        public IList<TipoFactura> GetAll()
        {
            List <TipoFactura> lst = new List<TipoFactura>();
            string sql = "select * from tipo_factura";
            var res = DataManager.GetInstance().ConsultaSQL(sql);

            foreach(DataRow row in res.Rows)
            {
                lst.Add(MappingTipoFactura(row));
            }
            return lst;
        }

        private TipoFactura MappingTipoFactura(DataRow row)
        {
            TipoFactura tipoFactura = new TipoFactura();

            tipoFactura.CodTipoFactura = Convert.ToChar(row["codtipofactura"]);
            tipoFactura.Nombre = row["nombre"].ToString();
            tipoFactura.Descripcion = row["descripcion"].ToString();

            return tipoFactura;
        }
    }
}
