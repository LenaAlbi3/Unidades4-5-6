namespace Diccionario.Modelos
{
    public static class Menu
    {
        static List<Action> Acciones = new List<Action>
        {
            AgregarProducto,
            EliminarProducto,
            ModificarProducto,
            MostrarProductos
        };

        public static void MostrarMenu()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n----- Menú -----\n" +
                    "1. Agregar Producto\n" +
                    "2. Eliminar Producto\n" +
                    "3. Modificar Producto\n" +
                    "4. Mostrar Productos\n" +
                    "5. Salir\n");
                Console.Write("Seleccione una opcion: ");
                string opcion = Console.ReadLine();

                if(int.TryParse(opcion, out int indice) &&  indice >= 1 && indice <= Acciones.Count + 1)
                {
                    if(indice == Acciones.Count + 1)
                    {
                        Console.WriteLine("Saliendo...");
                        salir = true;
                    }
                    else
                    {
                        Acciones[indice - 1].Invoke();
                    }
                }
            }
        }

        public static void AgregarProducto()
        {
            Console.Write("Ingrese el código del producto: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();

            Sys.AgregarProducto(new Producto(codigo, nombre));
        }

        public static void EliminarProducto()
        {
            if (Sys.listaProductos.Count == 0)
            {
                Console.WriteLine("No hay productos en la lista para eliminar.");
                return;
            }

            Console.Write("Ingrese el código del producto que quiere eliminar: ");
            int codigo = int.Parse(Console.ReadLine());

            Sys.EliminarProducto(codigo);
        }

        public static void ModificarProducto()
        {
            if (Sys.listaProductos.Count == 0)
            {
                Console.WriteLine("No hay productos en la lista para modificar.");
                return;
            }

            Console.Write("Ingrese el código del producto que quiere modificar: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el código del nuevo producto: ");
            int codigoNuevo = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nombre del nuevo producto: ");
            string nombreNuevo = Console.ReadLine();

            Producto nuevoProducto = new Producto(codigoNuevo, nombreNuevo);

            Sys.ModificarProducto(nuevoProducto, codigo);
        }

        public static void MostrarProductos() => Sys.MostrarProductos();
    }
}
