using TiendaVideojuegos.Enums;

namespace TiendaVideojuegos.Modelos
{
    public static class Menu
    {
        static List<Action> Acciones = new List<Action>
        {
            AgregarVideojuego,
            EliminarVideojuego,
            ActualizarVideojuego,
            MostrarCatalogo
        };

        public static void MostrarMenu()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n --- Menú ---\n" +
                    "1. Agregar Videojuego\n" +
                    "2. Eliminar Videojuego\n" +
                    "3. Modificar Videojuego\n" +
                    "4. Mostrar Videojuego\n" +
                    "5. Salir\n");
                Console.Write("Seleccione una opcion: ");
                string opcion = Console.ReadLine();

                if (int.TryParse(opcion, out int indice) && indice >= 1 && indice <= Acciones.Count + 1)
                {
                    if (indice == Acciones.Count + 1)
                    {
                        salir = true;
                    }
                    else
                    {
                        Acciones[indice - 1].Invoke();
                    }
                }
            }
        }

        public static void AgregarVideojuego()
        {
            Console.Write("Ingrese el nombre del videojuego: ");
            string nombre = Console.ReadLine();

            Console.Write("Seleccione la plataforma del videojuego: ");
            foreach(var plataforma in Enum.GetValues(typeof(Plataforma)))
            {
                Console.WriteLine($"{(int)plataforma}. {plataforma}");
            }
            int seleccionPlataforma = int.Parse(Console.ReadLine());
            Plataforma plataformaSeleccionada = (Plataforma)seleccionPlataforma;

            Console.Write("Ingrese el precio del videojuego: ");
            double precio = double.Parse(Console.ReadLine());

            Console.Write("Ingrese la cantidad en stock del videojuego: ");
            int cantidad = int.Parse(Console.ReadLine());

            var nuevoJuego = new Videojuego(nombre, plataformaSeleccionada, precio, cantidad);
            GestorVideojuegos.AgregarVideojuego(nuevoJuego);
        }

        public static void EliminarVideojuego()
        {
            if (GestorVideojuegos.Catalogo.Count == 0)
            {
                Console.WriteLine("El catálogo está vacío para eliminar");
                return;
            }

            Console.Write("Ingrese el nombre del videojuego que quiere eliminar: ");
            string nombre = Console.ReadLine();

            Console.Write("Seleccione la plataforma del videojuego que quiere eliminar: ");
            foreach (var plataforma in Enum.GetValues(typeof(Plataforma)))
            {
                Console.WriteLine($"{(int)plataforma}. {plataforma}");
            }
            int seleccionPlataforma = int.Parse(Console.ReadLine());
            Plataforma plataformaSeleccionada = (Plataforma)seleccionPlataforma;

            GestorVideojuegos.EliminarVideojuego(nombre, plataformaSeleccionada);
        }

        public static void ActualizarVideojuego()
        {
            if (GestorVideojuegos.Catalogo.Count == 0)
            {
                Console.WriteLine("El catálogo está vacío para actualizar");
                return;
            }

            Console.Write("Ingrese el nombre del videojuego que quiere modificar: ");
            string nombreAModoficar = Console.ReadLine();

            Console.Write("Seleccione la plataforma del videojuego que quiere modificar: ");
            foreach (var plataforma in Enum.GetValues(typeof(Plataforma)))
            {
                Console.WriteLine($"{(int)plataforma}. {plataforma}");
            }
            int seleccionPlataformaAModificar = int.Parse(Console.ReadLine());
            Plataforma plataformaSeleccionadaAModificar = (Plataforma)seleccionPlataformaAModificar;

            Console.Write("Ingrese el nombre del nuevo videojuego: ");
            string nombre = Console.ReadLine();

            Console.Write("Seleccione la plataforma del nuevo videojuego: ");
            foreach (var plataforma in Enum.GetValues(typeof(Plataforma)))
            {
                Console.WriteLine($"{(int)plataforma}. {plataforma}");
            }
            int seleccionPlataforma = int.Parse(Console.ReadLine());
            Plataforma plataformaSeleccionada = (Plataforma)seleccionPlataforma;

            Console.Write("Ingrese el precio del nuevo videojuego: ");
            double precio = double.Parse(Console.ReadLine());

            Console.Write("Ingrese la cantidad en stock del nuevo videojuego: ");
            int cantidad = int.Parse(Console.ReadLine());

            var juegoActualizado = new Videojuego(nombre, plataformaSeleccionada, precio, cantidad);

            GestorVideojuegos.ActualizarVideojuego(nombreAModoficar, plataformaSeleccionadaAModificar, juegoActualizado);
        }

        public static void MostrarCatalogo()
        {
            if (GestorVideojuegos.Catalogo.Count == 0)
            {
                Console.WriteLine("El catálogo está vacío para mostrar");
                return;
            }

            GestorVideojuegos.MostrarCatalogo();
        }
    }
}
