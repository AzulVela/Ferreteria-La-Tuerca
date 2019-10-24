using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.AccesoDatos;

namespace TpLaTuerca.LogicaNegocio
{
    class TipoUsoService
    {
        private TipoUsoDao oTipoUsoDao;

        public TipoUsoService()
        {
            oTipoUsoDao = new TipoUsoDao();
        }

        internal object ObtenerTodos()
        {
            return oTipoUsoDao.GetAll();
        }
    }
}
