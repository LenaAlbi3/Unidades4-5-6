using ViajeEspacial.Enums;

namespace ViajeEspacial.Modelos
{
    public static class Menu
    {
        static List<Action> Acciones = new List<Action>
        {
           AgregarMision,
           EliminarMision,
           ModificarMision,
           MostrarMisiones
        };

        public static void MostrarMenu()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n --- Menú de misiones ---\n" +
                    "1. Agregar mision\n" +
                    "2. Eliminar mision\n" +
                    "3. Modificar mision\n" +
                    "4. Mostrar mision\n" +
                    "5. Salir\n");
                Console.Write("Seleccione una opcion: ");
                string opcion = Console.ReadLine();

                if(int.TryParse(opcion, out int indice) && indice >= 1 && indice <= Acciones.Count+1)
                {
                    if(indice == Acciones.Count + 1)
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

        static Mision CrearMision(string nombre)
        {
            Console.WriteLine("Seleccione el destino: ");
            foreach (var destino in Enum.GetValues(typeof(Destino)))
            {
                Console.WriteLine($"{(int)destino}. {destino}");
            }
            int seleccionDestino = int.Parse(Console.ReadLine());
            Destino destinoSeleccionado = (Destino)seleccionDestino;

            Console.Write("Ingrese la cantidad de astronautas: ");
            int astronautas = int.Parse(Console.ReadLine());

            Console.WriteLine("Seleccione el tipo de mision: ");
            Console.WriteLine("1. Exploración.");
            Console.WriteLine("2. Colonización.");
            Console.WriteLine("3. Investigación.");

            int tipoMision = int.Parse(Console.ReadLine());

            Mision nuevaMision = null;

            switch (tipoMision)
            {
                case 1:
                    nuevaMision = new Exploracion(nombre, destinoSeleccionado, astronautas);
                    break;
                case 2:
                    Console.Write("Ingrese la cantidad de colonos: ");
                    int colonos = int.Parse(Console.ReadLine());
                    nuevaMision = new Colonizacion(nombre, destinoSeleccionado, astronautas, colonos);
                    break;
                case 3:
                    Console.WriteLine("Ingrese el campo de investigación");
                    nuevaMision = new Investigacion(nombre, destinoSeleccionado, astronautas, Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Tipo de misión inválido");
                    break;
            }
            return nuevaMision;
        }

        public static void AgregarMision()
        {
            Console.Write("Ingrese el nombre de la mision: ");
            string nombre = Console.ReadLine();

            var nuevaMision = CrearMision(nombre);
            GestionMisiones.AgregarMision(nuevaMision);
        }

        public static void EliminarMision()
        {
            Console.Write("Ingrese el nombre de la misión que quiera eliminar: ");
            string nombre = Console.ReadLine();
            GestionMisiones.EliminarMision(nombre);
        }

        public static void ModificarMision()
        {
            Console.Write("Ingrese el nombre de la misión que quiera modificar: ");
            string nombre = Console.ReadLine();

            var nuevaMision = CrearMision(nombre);

            GestionMisiones.ModificarMision(nombre, nuevaMision);
        }

        public static void MostrarMisiones() => GestionMisiones.MostrarMisiones();
    }
}
