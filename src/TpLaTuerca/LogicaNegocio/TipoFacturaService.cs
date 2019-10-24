using TpLaTuerca.AccesoDatos;

namespace TpLaTuerca.Presentacion.Factura
{
    internal class TipoFacturaService
    {
        private TipoFacturaDao oTipoFacturaDao;

        public TipoFacturaService()
        {
            oTipoFacturaDao = new TipoFacturaDao();
        }

        public object ObtenerTodos()
        {
            return oTipoFacturaDao.GetAll();
        }

    }
}