using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.AccesoDatos;

namespace TpLaTuerca.LogicaNegocio
{
    class ProveedorService
    {
        private ProveedorDao oProveedorDao;

        public ProveedorService()
        {
            oProveedorDao = new ProveedorDao();
        }

        internal object ObtenerTodos()
        {
            return oProveedorDao.GetAll();
        }
    }
}
