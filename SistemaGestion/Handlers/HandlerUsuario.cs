using System.Data.SqlClient;
using System.Data;
using SistemaGestion.Models;

public class HandlerUsuario
{
    public static List<Usuario> DevolverUsuario(string nombreUsuario)
    {
        var listaUsuarios = new List<Usuario>();

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

                            listaUsuarios.Add(usuario);

                        }

                        Console.WriteLine("----- Datos Usuario -----");
                        foreach (var usuario in listaUsuarios)
                        {
                            Console.WriteLine("Id = " + usuario.Id);
                            Console.WriteLine("Nombre = " + usuario.Nombre);
                            Console.WriteLine("Apellido = " + usuario.Apellido);
                            Console.WriteLine("Nombre de usuario = " + usuario.NombreUsuario);
                            Console.WriteLine("Contraseña = " + usuario.Contraseña);
                            Console.WriteLine("Mail = " + usuario.Mail);
                            
                            Console.WriteLine("---------------");

                        }

                        dr.Close();
                    }
                    else
                    {
                        Console.WriteLine("El Usuario no fue encontrado");
                    }

                }
            }
        }

        return listaUsuarios;



    }
    public static List<Usuario> InicioSesion(string nombreUsuario, string Contraseña)
    {
        var listaUsuarios = new List<Usuario>();

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

                            listaUsuarios.Add(usuario);

                        }

                        Console.WriteLine("----- Datos Usuario -----");
                        foreach (var usuario in listaUsuarios)
                        {
                            Console.WriteLine("Id = " + usuario.Id);
                            Console.WriteLine("Nombre = " + usuario.Nombre);
                            Console.WriteLine("Apellido = " + usuario.Apellido);
                            Console.WriteLine("Nombre de usuario = " + usuario.NombreUsuario);
                            Console.WriteLine("Contraseña = " + usuario.Contraseña);
                            Console.WriteLine("Mail = " + usuario.Mail);

                            Console.WriteLine("---------------");

                        }

                        dr.Close();
                    }
                    else
                    {
                        Console.WriteLine("El Usuario o la contraseña son incorrectas");
                    }

                }
            }
        }

        return listaUsuarios;



    }
}
