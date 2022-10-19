using SistemaGestion.Models;
using System.Data.SqlClient;

namespace SistemaGestion.Handlers
{
    internal class HandlerVenta
    {
        public static List<Venta> DevolverVenta(int idUsuario)
        {
            var listaVenta = new List<Venta>();

            var query = "SELECT Id, Comentarios, IdUsuario FROM Venta WHERE idUsuario = @idUsuario ";

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

                    parametro.ParameterName = "idUsuario";
                    parametro.SqlDbType = System.Data.SqlDbType.Int;
                    parametro.Value = idUsuario;
                    comando.Parameters.Add(parametro);

                    connection.Open();
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var Venta = new Venta();
                                Venta.Id = Convert.ToInt32(dr["Id"]);
                                Venta.Comentarios = dr["Comentarios"].ToString();
                                Venta.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);

                                listaVenta.Add(Venta);
                            }
                            Console.WriteLine("----- Ventas -----");

                            foreach (var Venta in listaVenta)
                            {
                                Console.WriteLine("Id = " + Venta.Id);
                                Console.WriteLine("Comentarios = " + Venta.Comentarios);
                                Console.WriteLine("IdUsuario = " + Venta.IdUsuario);
                                Console.WriteLine("---------------");
                            }
                            Console.WriteLine("Fin de Lista Venta");

                            dr.Close();
                        }
                    }
                }

            }
            return listaVenta;


        }
    }
}
