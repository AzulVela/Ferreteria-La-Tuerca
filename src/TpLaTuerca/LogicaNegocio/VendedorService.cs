using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.AccesoDatos;

namespace TpLaTuerca.LogicaNegocio
{
    class VendedorService
    {
        private VendedorDao oVendedorDao;

        public VendedorService()
        {
            oVendedorDao = new VendedorDao();
        }

        public object ObtenerTodos()
        {
            return oVendedorDao.GetAll();
        }
    }
}
