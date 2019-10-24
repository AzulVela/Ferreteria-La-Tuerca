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
                String strSql = string.Concat(" SELECT idUsuario, nombreUsuario, password, email",
                                              "   FROM Usuarios",
                                              "  WHERE nombreUsuario =  @usuario AND habilitado = 1");

                var parametros = new Dictionary<string, object>();

                parametros.Add("usuario", nombreUsuario);
                //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
                var resultado = DataManager.GetInstance().ConsultaSQLConParametros(strSql, parametros);

                // Validamos que el resultado tenga al menos una fila.
                if (resultado.Rows.Count > 0)
                {
                    return ObjectMapping(resultado.Rows[0]);
                }

                return null;
            }
        }

        internal bool Update(Usuario oUsuarioSelected)
        {
            String sql = "UPDATE usuarios SET nombreUsuario = @nombre, password = @password, email = @email WHERE idUsuario = @id";

            var parametros = new Dictionary<string, object>();

            parametros.Add("id", oUsuarioSelected.IdUsuario);
            parametros.Add("nombre",oUsuarioSelected.NombreUsuario);
            parametros.Add("password",oUsuarioSelected.Password);
            parametros.Add("email",oUsuarioSelected.Email);

            int resultado = DataManager.GetInstance().EjecutarSQL(sql, parametros);

            return resultado == 1;
        }

        internal bool UpdateState(Usuario oUsuarioSelected)
        {
            String sql = "UPDATE usuarios SET habilitado = 0 WHERE idUsuario = @id";

            var parametros = new Dictionary<string, object>();

            parametros.Add("id", oUsuarioSelected.IdUsuario);

            int resultado = DataManager.GetInstance().EjecutarSQL(sql, parametros);

            return resultado == 1;
        }

        internal bool Insert(Usuario oUsuario)
        {
            String sql = "INSERT INTO usuarios(nombreUsuario, password, email, estado) VALUES (@nombre, @password, @email, default)";

            var parametros = new Dictionary<string, object>();

            parametros.Add("nombre", oUsuario.NombreUsuario);
            parametros.Add("password", oUsuario.Password);
            parametros.Add("email", oUsuario.Email);

            int resultado = DataManager.GetInstance().EjecutarSQL(sql, parametros);

            return resultado == 1;
        }

        internal IList<Usuario> GetAll()
        {
            List<Usuario> listaUsuario = new List<Usuario>();

            String sql = "SELECT idUsuario, nombreUsuario, password, email FROM usuarios WHERE habilitado = 1";

            var resultado = DataManager.GetInstance().ConsultaSQL(sql);

            foreach (DataRow row in resultado.Rows)
            {
                listaUsuario.Add(ObjectMapping(row));
            }

            return listaUsuario;
        }

        private Usuario ObjectMapping(DataRow row)
        {
            Usuario oUsuario = new Usuario
            {
                IdUsuario = Convert.ToInt32(row["idUsuario"].ToString()),
                NombreUsuario = row["nombreUsuario"].ToString(),
                Password = row.Table.Columns.Contains("password") ? row["password"].ToString() : null,
                Email = row["email"].ToString()

            };

            return oUsuario;
        }
    }
}
