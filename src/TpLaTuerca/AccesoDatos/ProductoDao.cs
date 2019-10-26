using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.Entidades;

namespace TpLaTuerca.AccesoDatos
{
    class ProductoDao
    {
        internal object GetByFilters(Dictionary<string, object> filtros)
        {
            List<Producto> lst = new List<Producto>();
            String sql = string.Concat("select ",
                                       "p.CodProducto, ",
                                       "p.Nombre, ",
                                       "p.Descripcion, ",
                                       "tm.CodTipoMedida, ",
                                       "tm.Nombre as NombreTM, ",
                                       "tm.Descripcion as DescripcionTM, ",
                                       "tu.CodTipoUso, ",
                                       "p.Precio, ",
                                       "tu.Nombre as NombreTU, ",
                                       "tu.Descripcion as DescripcionTU, ",
                                       "pr.CodProveedor, ",
                                       "pr.Nombre as NombrePR ",
                                       "from producto p join tipo_medida tm on p.codtipomedida = tm.Codtipomedida ",
                                       "join tipo_uso tu on p.Codtipouso = tu.Codtipouso join proveedor pr on p.Codproveedor = pr.CodProveedor ",
                                       "where p.habilitado = 1 ");
            if (filtros.ContainsKey("codigo"))
            {
                sql += "and p.codproducto = @codigo ";
            }

            if (filtros.ContainsKey("idTipoUso"))
            {
                sql += "and tu.codtipouso = @idTipoUso";
            }

            var resultado = DataManager.GetInstance().ConsultaSQLConParametros(sql, filtros);

            foreach (DataRow row in resultado.Rows)
            {
                lst.Add(ObjectMapping(row));
            }
            return lst;
        }

        internal bool CreateProducto(Producto oProducto)
        {
            string sql = "insert into producto values (@nombre, @descripcion, @codtipomedida, @precio, @codtipouso,@codproveedor,default)";

            var prs = new Dictionary<string, object>();
            prs.Add("nombre", oProducto.Nombre);
            prs.Add("descripcion", oProducto.Descripcion);
            prs.Add("codtipomedida", oProducto.TipoMedida.CodTipoMedida);
            prs.Add("precio", oProducto.Precio);
            prs.Add("codtipouso", oProducto.TipoUso.CodTipoUso);
            prs.Add("codproveedor", oProducto.Proveedor.CodProveedor);

            return DataManager.GetInstance().EjecutarSQL(sql, prs) == 1;
        }

        internal Producto GetProducto(string text)
        {
            string sql = string.Concat("select ",
                                       "p.CodProducto, ",
                                       "p.Nombre, ",
                                       "p.Descripcion, ",
                                       "tm.CodTipoMedida, ",
                                       "tm.Nombre as 'NombreTM', ",
                                       "tm.Descripcion as 'DescripcionTM', ",
                                       "p.Precio, ",
                                       "tu.CodTipoUso, ",
                                       "tu.Nombre as 'NombreTU', ",
                                       "tu.Descripcion as 'DescripcionTU', ",
                                       "pr.CodProveedor, ",
                                       "pr.Apellido as 'NombrePR' ",
                                       "from producto p join tipo_medida tm on p.codtipomedida = tm.Codtipomedida ",
                                       "join tipo_uso tu on p.Codtipouso = tu.Codtipouso join proveedor pr on p.Codproveedor = pr.CodProveedor ",
                                       "where p.habilitado = 1 and p.nombre = @nombre "); 

            var prs = new Dictionary<string, object>();
            prs.Add("nombre", text);

            var res = DataManager.GetInstance().ConsultaSQLConParametros(sql, prs);

            if (res.Rows.Count > 0)
            {
                return ObjectMapping(res.Rows[0]);
            }
            return null;

        }

        public IList<Producto> GetAll()
        {
            List<Producto> lstProductos = new List<Producto>();

            String sql = string.Concat("select ",
                                       "p.CodProducto, ",
                                       "p.Nombre, ",
                                       "p.Descripcion, ",
                                       "tm.CodTipoMedida, ",
                                       "tm.Nombre as 'NombreTM', ",
                                       "tm.Descripcion as 'DescripcionTM', ",
                                       "p.Precio, ",
                                       "tu.CodTipoUso, ",
                                       "tu.Nombre as 'NombreTU', ",
                                       "tu.Descripcion as 'DescripcionTU', ",
                                       "pr.CodProveedor, ",
                                       "pr.Apellido as 'NombrePR' ",
                                       "from producto p join tipo_medida tm on p.codtipomedida = tm.Codtipomedida ",
                                       "join tipo_uso tu on p.Codtipouso = tu.Codtipouso join proveedor pr on p.Codproveedor = pr.CodProveedor ",
                                       "where p.habilitado = 1 ");

            var resultado = DataManager.GetInstance().ConsultaSQL(sql);

            foreach(DataRow row in resultado.Rows)
            {
                lstProductos.Add(ObjectMapping(row));
            }

            return lstProductos;
        }

        private Producto ObjectMapping(DataRow row)
        {
            Producto oProducto = new Producto
            {
                CodProducto = Convert.ToInt32(row["CodProducto"].ToString()),
                Nombre = row["Nombre"].ToString(),
                Descripcion = row["Descripcion"].ToString(),
                Precio = float.Parse(row["Precio"].ToString()),
                TipoMedida = new TipoMedida
                {
                    CodTipoMedida = Convert.ToInt32(row["CodTipoMedida"].ToString()),
                    Nombre = row["NombreTM"].ToString(),
                    Descripcion = row["DescripcionTM"].ToString()
                },
                TipoUso = new TipoUso
                {
                    CodTipoUso = Convert.ToInt32(row["CodTipoUso"].ToString()),
                    Nombre = row["NombreTU"].ToString(),
                    Descripcion = row["DescripcionTU"].ToString()
                },
                Proveedor = new Proveedor
                {
                    CodProveedor = Convert.ToInt32(row["CodProveedor"].ToString()),
                    Nombre = row["NombrePR"].ToString()
                }

            };

            return oProducto;
        }
    }
}
