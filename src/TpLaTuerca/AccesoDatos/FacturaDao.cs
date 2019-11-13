using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.Entidades;

namespace TpLaTuerca.AccesoDatos
{
    class FacturaDao
    {
        internal bool Create(Factura factura, bool var)
        {
            DataManager dm = new DataManager();
           try
           {
                dm.Open();
                dm.BeginTransaction();

                string sql = "insert into factura values (@codTipoFact, @codCliente, @codTipoDocV,@nroTipoDocV,@fecha)";

                var prs = new Dictionary<string, object>();
                prs.Add("codTipoFact", factura.TipoFactura.CodTipoFactura);
                prs.Add("codCliente", factura.Cliente.CodCliente);
                prs.Add("codTipoDocV", factura.Vendedor.TipoDoc.CodTipoDoc);
                prs.Add("nroTipoDocV", factura.Vendedor.NroDoc);
                prs.Add("fecha", factura.FechaFactura);

                var resultado = dm.EjecutarSQL(sql, prs);
                var idFactura = dm.ConsultaSQLScalar("select @@identity");

                string sql2 = "insert into detalle_factura values (@idDetalle,@idFactura,@codTipoFact,@codProducto,@cant,@precio)";
                string idDetalle = "1";
                int idDetalle_int = 1;

                foreach (var detalle in factura.DetalleFactura)
                {
                    var prs2 = new Dictionary<string, object>();
                    prs2.Add("idDetalle", idDetalle);
                    prs2.Add("idFactura", idFactura);
                    prs2.Add("codTipoFact", factura.TipoFactura.CodTipoFactura);
                    prs2.Add("codProducto", detalle.Producto.CodProducto);
                    prs2.Add("cant", detalle.Cantidad);
                    prs2.Add("precio", detalle.Precio);

                    dm.EjecutarSQL(sql2, prs2);

                    idDetalle_int ++;
                    idDetalle = idDetalle_int.ToString();
                }

                if (var)
                {
                    string sql3 = "INSERT INTO Cuenta_Corriente values (@NroFactura,@CodTipoFactura,@CodCliente,default)";

                    var prs3 = new Dictionary<string, object>();
                    prs3.Add("NroFactura", idFactura);
                    prs3.Add("CodTipoFactura", factura.TipoFactura.CodTipoFactura);
                    prs3.Add("CodCliente", factura.Cliente.CodCliente);

                    dm.EjecutarSQL(sql3, prs3);
                }

                dm.Commit();
           }

           catch (Exception ex)
           {
              dm.Rollback();
              throw ex;
           }

           finally
           {
                dm.Close();
           }
            return true;
        }

        internal string BuscarAlMayor()
        {
            string sql = "select max(NroFactura) from factura";

            string resultado = DataManager.GetInstance().ConsultaSQL(sql).Rows[0].ItemArray[0].ToString();

            return resultado;
        }
    }
}
