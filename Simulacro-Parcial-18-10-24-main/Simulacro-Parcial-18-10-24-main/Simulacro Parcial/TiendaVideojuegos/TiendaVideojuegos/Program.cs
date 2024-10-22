using TiendaVideojuegos.Modelos;

namespace TiendaVideojuegos
{
    public class Program
    {
        static void Main()
        {
            GestorVideojuegos.CargarDatos(GestorVideojuegos.ArchivoVideojuegos, "+");
            Menu.MostrarMenu();
        }
    }
}
