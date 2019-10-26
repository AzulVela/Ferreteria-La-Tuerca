using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.Entidades;

namespace TpLaTuerca.AccesoDatos
{
    class VendedorDao
    {
        internal object GetAll()
        {
            string sql = "select * from vendedor";
            var res = DataManager.GetInstance().ConsultaSQL(sql);

            List<Vendedor> lst = new List<Vendedor>();

            foreach (DataRow row in res.Rows)
            {
                lst.Add(MappingVendedor(row));
            }

            return lst;
        }

        private Vendedor MappingVendedor(DataRow row)
        {
            var vendedor = new Vendedor()
            {
                TipoDoc = new TipoDoc()
                {
                    CodTipoDoc = Convert.ToInt32(row["codtipodoc"].ToString())
                },

                NroDoc = Convert.ToInt32(row["nrotipodoc"].ToString()),
                FechaIngreso = Convert.ToDateTime(row["fechaingreso"]),
                FechaNacimiento = Convert.ToDateTime(row["fechanac"]),
                Apellido = row["Apellido"].ToString(),
                Nombre = row["Nombre"].ToString(),
                Telefono = row["telefono"].ToString()

            };

            return vendedor;
        }
    }
}
