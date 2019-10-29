using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.AccesoDatos;
using TpLaTuerca.Entidades;

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

        internal object ObtenerTodos(Dictionary<string, object> filtros)
        {
            return oProveedorDao.GetAll();
        }

        internal IList<Proveedor> ConsultarConFiltros(Dictionary<string, object> filtros)
        {
            return oProveedorDao.GetByFilters(filtros);
        }

        internal bool CrearProveedor(Proveedor oProveedor)
        {
            return oProveedorDao.Insert(oProveedor);
        }

        internal bool ActualizarProveedor(Proveedor oProveedor)
        {
            return oProveedorDao.Update(oProveedor);
        }

        internal bool ModificarEstadoProveedor(Proveedor oProveedor)
        {
            return oProveedorDao.UpdateState(oProveedor);
        }

        internal object ObtenerProveedor(Proveedor oProveedor)
        {
            return oProveedorDao.GetProveedor(oProveedor);
        }
    }
}
