using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.Entidades;
using TpLaTuerca.AccesoDatos;

namespace TpLaTuerca.LogicaNegocio
{

    public class CuentaCorrienteService
    {
        public CuentaCorrienteDao oCuentaCorrienteDao;

        public CuentaCorrienteService()
        {
            oCuentaCorrienteDao = new CuentaCorrienteDao();
        }

        internal List<ResumenCuentCte> ObtenerCuentaCliente(Cliente oClienteSeleccionado)
        {
            return oCuentaCorrienteDao.ObtenerCuentaCliente(oClienteSeleccionado);
        }

        internal bool UpdateEstado(ResumenCuentCte resumen)
        {
            return oCuentaCorrienteDao.UpdateEstado(resumen);
        }
    }
}
