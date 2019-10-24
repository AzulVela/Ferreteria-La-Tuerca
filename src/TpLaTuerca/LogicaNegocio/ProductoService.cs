using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.AccesoDatos;
using TpLaTuerca.Entidades;

namespace TpLaTuerca.LogicaNegocio
{
    class ProductoService
    {
        private ProductoDao oProductoDao;
        public ProductoService()
        {
            oProductoDao = new ProductoDao();
        }

        internal object ConsultarConFiltro(Dictionary<string, object> filtros)
        {
            return oProductoDao.GetByFilters(filtros);
        }

        internal object ObtenerTodos(Dictionary<string, object> filtros)
        {
            return oProductoDao.GetAll();
        }

        internal object ObtenerProducto(string text)
        {
            return oProductoDao.GetProducto(text);
        }

        internal bool CrearProducto(Producto oProducto)
        {
            return oProductoDao.CreateProducto(oProducto);
        }
    }
}
