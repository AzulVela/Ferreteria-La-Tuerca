using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.AccesoDatos;

namespace TpLaTuerca.LogicaNegocio
{
    class TipoMedidaService
    {
        private TipoMedidaDao oTipoMedidaDao;

        public TipoMedidaService()
        {
            oTipoMedidaDao = new TipoMedidaDao();
        }

        internal object ObtenerTodos()
        {
            return oTipoMedidaDao.GetAll();
        }
    }
}
