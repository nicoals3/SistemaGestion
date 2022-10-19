using SistemaGestion.Models;
using SistemaGestion.Handlers;

internal class Program
{
    private static void Main(string[] args)
    {
        HandlerUsuario.DevolverUsuario("NLopez");
        HandlerUsuario.InicioSesion("NLopez", "SoyNicoLoez");      
        HandlerProducto.DevolverProducto(3);
        HandlerProductoVendido.DevolverProductoVendido(1);
        HandlerVenta.DevolverVenta(1);
    }
}