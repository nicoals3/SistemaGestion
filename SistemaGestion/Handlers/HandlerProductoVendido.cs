using SistemaGestion.Models;
using System.Data.SqlClient;

namespace SistemaGestion.Handlers
{
    public class HandlerProductoVendido
    {
        public static List<ProductoVendido> DevolverProductoVendido(int idVenta)
        {
            var listaProductoVendido = new List<ProductoVendido>();

            var query = "SELECT P.Id, Descripciones, PV.Stock, IdVenta FROM Producto AS P INNER JOIN ProductoVendido AS PV ON P.Id = PV.IdProducto WHERE IdVenta = @idVenta ";

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

                    parametro.ParameterName = "idVenta";
                    parametro.SqlDbType = System.Data.SqlDbType.Int;
                    parametro.Value = idVenta;
                    comando.Parameters.Add(parametro);

                    connection.Open();
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var ProductoVendido = new ProductoVendido();
                                ProductoVendido.Id = Convert.ToInt32(dr["Id"]);
                                ProductoVendido.Descripciones = dr["Descripciones"].ToString();
                                ProductoVendido.Stock = Convert.ToInt32(dr["Stock"]);
                                ProductoVendido.IdVenta = Convert.ToInt32(dr["IdVenta"]);

                                listaProductoVendido.Add(ProductoVendido);
                            }
                            Console.WriteLine("----- Productos Vendidos -----");

                            foreach (var ProductoVendido in listaProductoVendido)
                            {
                                Console.WriteLine("Id Producto = " + ProductoVendido.Id);
                                Console.WriteLine("Descripcion = " + ProductoVendido.Descripciones);
                                Console.WriteLine("Stock = " + ProductoVendido.Stock);
                                Console.WriteLine("Id de Venta = " + ProductoVendido.IdVenta);
                                Console.WriteLine("---------------");
                            }
                            Console.WriteLine("Fin de Lista Productos Vendidos");

                            dr.Close();
                        }
                    }
                }

            }
            return listaProductoVendido;


        }
    }
}
