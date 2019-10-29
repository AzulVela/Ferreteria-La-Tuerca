using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.Entidades;

namespace TpLaTuerca.AccesoDatos
{
    class ProveedorDao
    {
        public IList<Proveedor> GetAll()
        {
            List<Proveedor> listaProveedor = new List<Proveedor>();

            String sql = "select * from proveedor where habilitado = 1";

            var resultado = DataManager.GetInstance().ConsultaSQL(sql);

            foreach(DataRow row in resultado.Rows)
            {
                listaProveedor.Add(ObjectMapping(row));
            }

            return listaProveedor;
        }

        private Proveedor ObjectMapping(DataRow dataRow)
        {
            Proveedor oProveedor = new Proveedor
            {
                CodProveedor = Convert.ToInt32(dataRow["CodProveedor"].ToString()),
                Apellido = dataRow["Apellido"].ToString(),
                Nombre = dataRow["Nombre"].ToString(),
                Direccion = dataRow["Direccion"].ToString(),
                Telefono = dataRow["Telefono"].ToString(),
                //TiempoEntrega = Convert.ToInt32(dataRow["TiempoDeEntrega"].ToString()),
            };

            return oProveedor;
        }

        internal bool Update(Proveedor oProveedorSelected)
        {
            String sql = "UPDATE proveedor SET Nombre = @nombre, Apellido = @apellido, Direccion = @direccion, Telefono = @telefono, TiempoDeEntrega = @tiempoEntrega WHERE CodProveedor = @cod";

            var parametros = new Dictionary<string, object>();

            parametros.Add("cod", oProveedorSelected.CodProveedor);
            parametros.Add("nombre", oProveedorSelected.Nombre);
            parametros.Add("apellido", oProveedorSelected.Apellido);
            parametros.Add("direccion", oProveedorSelected.Direccion);
            parametros.Add("telefono", oProveedorSelected.Telefono);
            parametros.Add("tiempoEntrega", oProveedorSelected.TiempoEntrega);

            int resultado = DataManager.GetInstance().EjecutarSQL(sql, parametros);

            return resultado == 1;
        }

        internal object GetProveedor(Proveedor oProveedor)
        {
            var cod = oProveedor.CodProveedor;

            String sql = "select CodProveedor, Apellido, Nombre, Direccion, Telefono, TiempoDeEntrega from Proveeodr where CodProveedor = @cod";

            var param = new Dictionary<string, object>();

            param.Add("cod", cod);

            var resultado = DataManager.GetInstance().ConsultaSQLConParametros(sql, param);

            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }

        internal bool UpdateState(Proveedor oProveedorSelected)
        {
            String sql = "UPDATE proveedor SET habilitado = 0 WHERE CodProveedor = @cod";

            var parametros = new Dictionary<string, object>();

            parametros.Add("cod", oProveedorSelected.CodProveedor);

            int resultado = DataManager.GetInstance().EjecutarSQL(sql, parametros);

            return resultado == 1;
        }

        internal bool Insert(Proveedor oProveedorSelected)
        {
            String sql = "INSERT INTO proveedor(Nombre, Apellido, Direccion, Telefono, TiempoDeEntrega, Habilitado) VALUES (@nombre, @apellido, @direccion, @telefono,@tiempoEntrega, default)";

            var parametros = new Dictionary<string, object>();

            parametros.Add("cod", oProveedorSelected.CodProveedor);
            parametros.Add("nombre", oProveedorSelected.Nombre);
            parametros.Add("apellido", oProveedorSelected.Apellido);
            parametros.Add("direccion", oProveedorSelected.Direccion);
            parametros.Add("telefono", oProveedorSelected.Telefono);
            parametros.Add("tiempoEntrega", oProveedorSelected.TiempoEntrega);

            int resultado = DataManager.GetInstance().EjecutarSQL(sql, parametros);

            return resultado == 1;
        }

        public IList<Proveedor> GetByFilters(Dictionary<string, object> parametros)
        {
            List<Proveedor> lista = new List<Proveedor>();

            String sql = "SELECT * FROM Proveedor where habilitado = 1";

            if (parametros.ContainsKey("Nombre"))
            {
                sql += "AND (Nombre LIKE @Nombre)";
            }

            if (parametros.ContainsKey("Apellido"))
            {
                sql += "AND (Apellido LIKE @Apellido)";
            }

            var resultado = DataManager.GetInstance().ConsultaSQLConParametros(sql, parametros);

            foreach (DataRow row in resultado.Rows)
                lista.Add(ObjectMapping(row));

            return lista;
        }
    }
}
