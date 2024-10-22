using Diccionario.Modelos;

namespace Diccionario
{
    public class Program
    {
        static void Main()
        {
            Sys.CargarDatos(Sys.ArchivoProductos, "+");
            Menu.MostrarMenu();
        }
    }
}