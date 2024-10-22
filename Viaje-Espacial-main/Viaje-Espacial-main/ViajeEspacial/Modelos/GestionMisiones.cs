using ViajeEspacial.Enums;

namespace ViajeEspacial.Modelos
{
    public static class GestionMisiones
    {
        static List<Mision> Misiones = new();
        public readonly static string ArchivoMisiones = "misiones.txt";

        public static void AgregarMision(Mision mision)
        {
            Misiones.Add(mision);
            GuardarDatos(mision, ArchivoMisiones, true);
            Console.WriteLine($"Mision '{mision.Nombre}' agregada");
        }

        public static void EliminarMision(string nombre)
        {
            var mision = Misiones.Find(m => m.Nombre == nombre);

            if (mision == null)
            {
                Console.WriteLine($"Mision '{nombre}' no encontrada");
                return;
            }

            Misiones.Remove(mision);
            GuardarDatos(Misiones, ArchivoMisiones, false);
            Console.WriteLine($"Mision '{nombre}' eliminada");
        }

        public static void ModificarMision(string nombre, Mision nuevaMision)
        {
            var mision = Misiones.Find(m => m.Nombre == nombre);

            if(mision == null)
            {
                Console.WriteLine($"Mision '{nombre}' no encontrada");
                return;
            }

            Misiones.Remove(mision);
            Misiones.Add(nuevaMision);
            GuardarDatos(Misiones, ArchivoMisiones, false);
            Console.WriteLine($"Misión '{nombre}' modificada");
        }

        public static void MostrarMisiones()
        {
            if(Misiones.Count == 0)
            {
                Console.WriteLine("No hay misiones");
                return;
            }

            Console.WriteLine("Lista de misiones:");
            foreach(var mision in Misiones)
            {
                Console.WriteLine(mision);
            }
        }

        public static void GuardarDatos<T>(T entidad, string archivo, bool append) where T : class
        {
            using StreamWriter writer = new StreamWriter(archivo, append);
            writer.WriteLine(entidad);
        }

        public static void GuardarDatos<T>(List<T> entidades, string archivo, bool append) where T : class
        {
            using StreamWriter writer = new StreamWriter(archivo, append);
            foreach (T entidad in entidades)
            {
                writer.WriteLine(entidad);
            }
        }

        static string ConvertirArchivoACadenaDeTexto(string archivo, string separador)
        {
            if (File.Exists(archivo))
            {
                using StreamReader reader = new StreamReader(archivo);
                string linea;
                string archivoEnCadena = null;

                while((linea = reader.ReadLine()) != null)
                {
                    archivoEnCadena += linea + separador;
                }
                return archivoEnCadena;
            }
            return null;
        }

        public static void CargarDatos(string archivo)
        {
            try
            {
                string archivoEnCadena = ConvertirArchivoACadenaDeTexto(archivo, "+");
                if (archivoEnCadena == null)
                {
                    return;
                }
                string[] misiones = archivoEnCadena.Split("+", StringSplitOptions.RemoveEmptyEntries);

                foreach (var mision in misiones)
                {
                    string[] datos = mision.Split(", ");

                    Mision misionLeida = null;

                    string nombre = datos[1];
                    Destino destino = (Destino)Enum.Parse(typeof(Destino), datos[2]);
                    int astronautas = int.Parse(datos[3]);

                    if (datos[0] == typeof(Exploracion).Name)
                    {
                        misionLeida = new Exploracion(nombre, destino, astronautas);
                    }
                    if (datos[0] == typeof(Colonizacion).Name)
                    {
                        misionLeida = new Colonizacion(nombre, destino, astronautas, int.Parse(datos[4]));
                    }
                    if (datos[0] == typeof(Investigacion).Name)
                    {
                        misionLeida = new Investigacion(nombre, destino, astronautas, datos[4]);
                    }

                    Misiones.Add(misionLeida);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar datos desde el archivo {archivo}: {ex.Message}");
            }
        }
    }
}
