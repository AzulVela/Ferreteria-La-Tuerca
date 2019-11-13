using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.Entidades;

namespace TpLaTuerca.AccesoDatos
{
    public class CuentaCorrienteDao
    {
        public CuentaCorrienteDao()
        {

        }

        internal List<ResumenCuentCte> ObtenerCuentaCliente(Cliente oClienteSeleccionado)
        {
            List<ResumenCuentCte> lista = new List<ResumenCuentCte>();

            string sql = "SELECT FC.NroFactura, FC.CodTipoFactura, FC.Fecha, SUM(DF.Cantidad*DF.Precio) as Importe " +
                            "FROM Cuenta_Corriente CC, Factura FC, Detalle_Factura DF " +
                            "WHERE CC.NroFactura = FC.NroFactura " +
                            "AND CC.CodTipoFactura = FC.CodTipoFactura " +
                            "AND FC.NroFactura = DF.NroFactura " +
                            "AND FC.CodTipoFactura = DF.CodTipoFactura " +
                            "AND FC.CodCliente = " + oClienteSeleccionado.CodCliente.ToString() +
                            "AND CC.habilitado = 1 " +
                            "GROUP BY FC.NroFactura, FC.CodTipoFactura, FC.Fecha ";

            var resultado = DataManager.GetInstance().ConsultaSQL(sql);
            
            foreach(DataRow row in resultado.Rows)
            {
                lista.Add(ObjectMapping(row));
            }

            return lista;
        }

        internal bool UpdateEstado(ResumenCuentCte resumen)
        {
            Dictionary<string, object> cuenta = new Dictionary<string, object>();

            string sql = "UPDATE Cuenta_Corriente" +
                        " SET habilitado = 0" +
                        " WHERE NroFactura = @NroFactura" +
                        " AND CodTipoFactura = @CodTipoFactura";

            cuenta.Add("NroFactura", resumen.NroFactura);
            cuenta.Add("CodTipoFactura", resumen.CodTipoFactura);

            var resultado = DataManager.GetInstance().EjecutarSQL(sql,cuenta);

            return resultado == 1;
        }

        private ResumenCuentCte ObjectMapping(DataRow row)
        {
            ResumenCuentCte resumen = new ResumenCuentCte
            {
                NroFactura = Convert.ToInt32(row["NroFactura"].ToString()),
                CodTipoFactura = Convert.ToInt32(row["CodTipoFactura"].ToString()),
                Fecha = Convert.ToDateTime(row["Fecha"].ToString()),
                Importe = Convert.ToDouble(row["Importe"].ToString())
            };

            return resumen;
        }
    }
}
