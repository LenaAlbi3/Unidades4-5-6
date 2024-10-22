using TiendaVideojuegos.Enums;

namespace TiendaVideojuegos.Modelos
{
    public static class GestorVideojuegos
    {
        public static List<Videojuego> Catalogo = new();
        public static readonly string ArchivoVideojuegos = "videojuegos.txt";

        public static void AgregarVideojuego(Videojuego videojuego)
        {
            var juego = Catalogo.Find(v => v.Nombre == videojuego.Nombre && v.Plataforma == videojuego.Plataforma);

            if (juego != null)
            {
                Console.WriteLine("Este juego ya existe en el catalogo");
            }

            Catalogo.Add(videojuego);
            GuardarDatos(videojuego, true);
            Console.WriteLine("Juego agregado!");
        }

        public static void EliminarVideojuego(string nombre, Plataforma plataforma)
        {
            var juego = Catalogo.Find(v => v.Nombre == nombre && v.Plataforma == plataforma);

            if (juego == null)
            {
                Console.WriteLine("Este juego no existe en el catálogo");
            }

            Catalogo.Remove(juego);
            GuardarDatos(Catalogo, false);
            Console.WriteLine("Juego eliminado!");
        }

        public static void ActualizarVideojuego(string nombre, Plataforma plataforma, Videojuego nuevoJuego)
        {
            var juego = Catalogo.Find(v => v.Nombre == nombre && v.Plataforma == plataforma);

            if (juego == null)
            {
                Console.WriteLine("Este juego no existe en el catálogo");
            }

            Catalogo.Remove(juego);
            Catalogo.Add(nuevoJuego);
            GuardarDatos(Catalogo, false);
            Console.WriteLine("Juego actualizado!");
        }

        public static void MostrarCatalogo()
        {
            Console.WriteLine("Catálogo de videojuegos:");
            foreach (var juego in Catalogo)
            {
                Console.WriteLine(juego);
            }
        }

        public static void GuardarDatos<T>(T entidad, bool append) where T : class
        {
            using StreamWriter writer = new StreamWriter(ArchivoVideojuegos, append);
            writer.WriteLine(entidad);
        }

        public static void GuardarDatos<T>(List<T> entidades, bool append) where T : class
        {
            using StreamWriter writer = new StreamWriter(ArchivoVideojuegos, append);
            foreach (var entidad in entidades)
            {
                writer.WriteLine(entidad);
            }
        }

        public static string ConvertirArchivoEnCadena(string archivo, string separadorDeEntidades)
        {
            if (File.Exists(archivo))
            {
                string archivoConvertido = "";
                foreach (var linea in File.ReadAllLines(archivo))
                {
                    archivoConvertido += (linea + separadorDeEntidades);
                }
                return archivoConvertido;
            }
            return "";
        }

        public static void CargarDatos(string archivo, string separadorDeEntidades)
        {
            try
            {
                string cadenaArchivo = ConvertirArchivoEnCadena(archivo, separadorDeEntidades);

                if (string.IsNullOrEmpty(cadenaArchivo))
                {
                    return;
                }

                string[] productos = cadenaArchivo.Split(separadorDeEntidades, StringSplitOptions.RemoveEmptyEntries);

                foreach (var producto in productos)
                {
                    string[] datos = producto.Split("-");

                    string nombre = datos[0];
                    Plataforma plataforma = (Plataforma)Enum.Parse(typeof(Plataforma), datos[1]);
                    double precio = double.Parse(datos[2]);
                    int cantidad = int.Parse(datos[3]);

                    Videojuego videojuegoLeido = new Videojuego(nombre, plataforma, precio, cantidad);
                    Catalogo.Add(videojuegoLeido);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar datos desde el archivo {archivo}: {ex.Message}");
            }
        }
    }
}
