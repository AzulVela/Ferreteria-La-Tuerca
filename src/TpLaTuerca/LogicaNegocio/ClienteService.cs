using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.AccesoDatos;
using TpLaTuerca.Entidades;

namespace TpLaTuerca.LogicaNegocio
{
    class ClienteService
    {
        private ClienteDao oClienteDao;
        public ClienteService()
        {
            oClienteDao = new ClienteDao();
        }

        internal object ObtenerCliente(string cuit)
        {
            return oClienteDao.GetCliente(cuit);
        }

        internal bool CrearCliente(Cliente oCliente)
        {
            return oClienteDao.Create(oCliente);
        }

        internal object ObtenerTodos()
        {
            return oClienteDao.GetAll();
        }
    }
}
