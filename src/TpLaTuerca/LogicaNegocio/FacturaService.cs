using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.AccesoDatos;
using TpLaTuerca.Entidades;

namespace TpLaTuerca.LogicaNegocio
{
    class FacturaService
    {
        private FacturaDao oFacturaDao;

        public FacturaService()
        {
            oFacturaDao = new FacturaDao();
        }

        internal bool ValidarDatos(Factura factura)
        {
            if (factura.DetalleFactura.Count == 0)
            {
                throw new Exception("Debe ingresar al menos un detalle");
            }

            return true;
        }

        internal void Crear(Factura factura)
        {
            oFacturaDao.Create(factura);
        }
    }
}
