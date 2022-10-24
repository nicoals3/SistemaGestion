using System.Data.SqlClient;
using System.Data;
using SistemaGestion.Models;

public class HandlerUsuario
{
    public static Usuario DevolverUsuario(string nombreUsuario)
    {
        var UsuarioDevuelto = new Usuario();

        var query = "SELECT Id,Nombre,Apellido,NombreUsuario,Contraseña,Mail FROM Usuario WHERE NombreUsuario = @NombreUsuario";

        SqlConnectionStringBuilder connecctionbuilder = new();
        connecctionbuilder.DataSource = "NICO-PC\\SQLEXPRESS";
        connecctionbuilder.InitialCatalog = "SistemaGestion";
        connecctionbuilder.IntegratedSecurity = true;
        var cs = connecctionbuilder.ConnectionString;

        using (SqlConnection connection = new SqlConnection(cs))
        {
            using (SqlCommand comando = new SqlCommand(query, connection))
            {
                var parametro = new SqlParameter();
                parametro.ParameterName = "NombreUsuario";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = nombreUsuario;
                comando.Parameters.Add(parametro);

                connection.Open();
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var usuario = new Usuario();
                            usuario.Id = Convert.ToInt32(dr["Id"]);
                            usuario.Nombre = dr["Nombre"].ToString();
                            usuario.Apellido = dr["Apellido"].ToString();
                            usuario.NombreUsuario = dr["NombreUsuario"].ToString();
                            usuario.Contraseña = dr["Contraseña"].ToString();
                            usuario.Mail = dr["Mail"].ToString();
                        }
                        dr.Close();
                    }

                }
            }
        }

        return UsuarioDevuelto;



    }
    public static Usuario InicioSesion(string nombreUsuario, string Contraseña)
    {
        var UsuarioIniciado = new Usuario();

        var query = "SELECT Id,Nombre,Apellido,NombreUsuario,Contraseña,Mail FROM Usuario WHERE NombreUsuario = @NombreUsuario AND Contraseña = @Contraseña";

        SqlConnectionStringBuilder connecctionbuilder = new();
        connecctionbuilder.DataSource = "NICO-PC\\SQLEXPRESS";
        connecctionbuilder.InitialCatalog = "SistemaGestion";
        connecctionbuilder.IntegratedSecurity = true;
        var cs = connecctionbuilder.ConnectionString;

        using (SqlConnection connection = new SqlConnection(cs))
        {
            using (SqlCommand comando = new SqlCommand(query, connection))
            {
                var parametro = new SqlParameter();
                parametro.ParameterName = "NombreUsuario";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = nombreUsuario;
                comando.Parameters.Add(parametro);
                
                var parametro2 = new SqlParameter();
                parametro2.ParameterName = "Contraseña";
                parametro2.SqlDbType = SqlDbType.VarChar;
                parametro2.Value = Contraseña;
                comando.Parameters.Add(parametro2);

                connection.Open();
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var usuario = new Usuario();
                            usuario.Id = Convert.ToInt32(dr["Id"]);
                            usuario.Nombre = dr["Nombre"].ToString();
                            usuario.Apellido = dr["Apellido"].ToString();
                            usuario.NombreUsuario = dr["NombreUsuario"].ToString();
                            usuario.Contraseña = dr["Contraseña"].ToString();
                            usuario.Mail = dr["Mail"].ToString();
                        }
                        dr.Close();
                    }

                }
            }
        }

        return UsuarioIniciado;



    }
}
