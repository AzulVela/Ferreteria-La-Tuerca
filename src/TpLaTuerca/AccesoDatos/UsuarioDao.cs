using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpLaTuerca.Entidades;

namespace TpLaTuerca.AccesoDatos
{
    class UsuarioDao
    {
        public Usuario GetUser(string nombreUsuario)
        {
            {
                //Construimos la consulta sql para buscar el usuario en la base de datos.
                String strSql = string.Concat(" SELECT *",
                                              "   FROM Usuarios",
                                              "  WHERE nombreUsuario =  @usuario");

                var parametros = new Dictionary<string, object>();
                parametros.Add("usuario", nombreUsuario);
                //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
                var resultado = DBHelper.GetDBHelper().ConsultaSQLConParametros(strSql, parametros);

                // Validamos que el resultado tenga al menos una fila.
                if (resultado.Rows.Count > 0)
                {
                    return ObjectMapping(resultado.Rows[0]);
                }

                return null;
            }
        }

        internal IList<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        private Usuario ObjectMapping(DataRow row)
        {
            Usuario oUsuario = new Usuario
            {
                IdUsuario = Convert.ToInt32(row["idUsuario"].ToString()),
                NombreUsuario = row["nombreUsuario"].ToString(),
                Password = row.Table.Columns.Contains("password") ? row["password"].ToString() : null,

            };

            return oUsuario;
        }
    }
}
