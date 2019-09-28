using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.Entidades;

namespace TpLaTuerca.AccesoDatos
{
    class ClienteDao
    {
        public Entidades.Cliente GetCliente(string cuit)
        {
            String sql = "select codcliente, Apellido, nombre, telefono, cuit from cliente where nombre = @cuit";
            var prs = new Dictionary<string, object>();
            prs.Add("cuit", cuit);

            var resultado = DBHelper.GetDBHelper().ConsultaSQLConParametros(sql, prs);

            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }

        public IList<Cliente> GetAll()
        {
            List<Cliente> listaCliente = new List<Cliente>();

            String sql = "select codcliente, Apellido, nombre, telefono, cuit from cliente where estado = 's'";

            var resultado = DBHelper.GetDBHelper().ConsultaSQL(sql);

            foreach(DataRow row in resultado.Rows)
            {
                listaCliente.Add(ObjectMapping(row));
            }

            return listaCliente;
        }

        internal bool ChangeStateClient(Cliente oClienteSelected)
        {
            String sql = "update cliente set estado = 'n' where codcliente = @codcliente";
            var prs = new Dictionary<string, object>();
            prs.Add("codcliente", oClienteSelected.CodCliente);

            return DBHelper.GetDBHelper().EjecutarSQL(sql, prs) == 1;
        }

        internal bool UpdateClient(Cliente oClienteSelected)
        {
            String sql = "update cliente set apellido = @apellido, nombre = @nombre, telefono = @telefono, cuit = @cuit where codcliente = @codcliente";
            var prs = new Dictionary<string, object>();
            prs.Add("apellido", oClienteSelected.Apellido);
            prs.Add("codcliente", oClienteSelected.CodCliente);
            prs.Add("nombre", oClienteSelected.Nombre);
            prs.Add("telefono", oClienteSelected.Telefono);
            prs.Add("cuit", oClienteSelected.CUIT);

            return DBHelper.GetDBHelper().EjecutarSQL(sql, prs) == 1;
        }

        internal bool Create(Cliente oCliente)
        {
            string sql = "insert into cliente values (@apellido,@nombre,@telefono,@cuit,default)";

            var prs = new Dictionary<string, object>();
            prs.Add("apellido", oCliente.Apellido);
            prs.Add("nombre", oCliente.Nombre);
            prs.Add("telefono", oCliente.Telefono);
            prs.Add("cuit", oCliente.CUIT);

            return (DBHelper.GetDBHelper().EjecutarSQL(sql, prs) == 1);
        }

        private Cliente ObjectMapping(DataRow dataRow)
        {
            Cliente oCliente = new Cliente
            {
                CodCliente = Convert.ToInt32(dataRow["codcliente"].ToString()),
                Nombre = dataRow["Nombre"].ToString(),
                Apellido = dataRow["Apellido"].ToString(),
                CUIT = dataRow["CUIT"].ToString(),
                Telefono = dataRow["telefono"].ToString()

            };

            return oCliente;
        }
    }
}
