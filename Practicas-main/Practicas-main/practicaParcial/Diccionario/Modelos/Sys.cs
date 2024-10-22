namespace Diccionario.Modelos
{
    public static class Sys
    {
        public static Dictionary<int, Producto> listaProductos = new();
        public static readonly string ArchivoProductos = "productos.txt";

        public static void AgregarProducto(Producto producto)
        {
            listaProductos.Add(producto.Codigo, producto);
            GuardarDatos(producto, true);
        }

        public static void EliminarProducto(int codigo)
        {
            if (!listaProductos.ContainsKey(codigo))
            {
                Console.WriteLine("Este codigo no existe.");
                return;
            }

            listaProductos.Remove(codigo);
            GuardarDatos(listaProductos, false);
        }

        public static void ModificarProducto(Producto nuevoProducto, int codigo)
        {
            if (!listaProductos.ContainsKey(codigo))
            {
                Console.WriteLine("El código del producto que quiere modificar no existe.");
                return;
            }

            listaProductos.Remove(codigo);

            if (listaProductos.ContainsKey(nuevoProducto.Codigo))
            {
                Console.WriteLine($"Este código ya existe en el producto {listaProductos[nuevoProducto.Codigo].Nombre}");
                return;
            }

            listaProductos.Add(nuevoProducto.Codigo, nuevoProducto);
            GuardarDatos(listaProductos, false);
        }

        public static void MostrarProductos()
        {
            if (listaProductos.Count == 0)
            {
                Console.WriteLine("No hay productos en la lista para mostrar.");
                return;
            }

            foreach(var producto in listaProductos.Values)
            {
                Console.WriteLine(producto.MostrarDatos());
            }
        }

        public static void GuardarDatos<T>(T entidad, bool append) where T : class
        {
            using StreamWriter writer = new StreamWriter(ArchivoProductos, append);
            writer.WriteLine(entidad);
        }

        public static void GuardarDatos<T>(Dictionary<int,T> entidades, bool append) where T : class
        {
            using StreamWriter writer = new StreamWriter(ArchivoProductos, append);
            foreach(var entidad in entidades.Values)
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

                foreach(var producto in productos)
                {
                    string[] datos = producto.Split("-");

                    //desde aca es personalizado dependiendo del ejercicio ////////////

                    Producto productoLeido = new Producto(int.Parse(datos[0]), datos[1]);

                    listaProductos.Add(productoLeido.Codigo, productoLeido);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar datos desde el archivo {archivo}: {ex.Message}");
            }
        }
    }
}
