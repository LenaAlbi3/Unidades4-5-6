using Empleados.Enums;

namespace Empleados.Modelos
{
    public class SysEmpleados
    {
        static Dictionary<int, Empleado> Empleados = new();
        public static string ArchivoEmpleados = "empleados.txt";

        public static void MostrarEmpleados()
        {
            if(Empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados para mostrar.");
                return;
            }
            Console.WriteLine("Lista de Empleados: ");
            foreach(var empleado in Empleados.Values)
            {
                Console.WriteLine(empleado);
            }
        }

        public static void MostrarEmpleadosPorDepartamento()
        {
            if (Empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados para mostrar.");
                return;
            }

            Console.WriteLine("Seleccione el departamento para ver sus empleados:");
            foreach(var departemento in Enum.GetValues(typeof(Departamento)))
            {
                Console.WriteLine($"{(int)departemento}. {departemento}");
            }
            int depIndex = int.Parse(Console.ReadLine());

            bool empleadosEnDepartamento = false;
            foreach(var empleado in Empleados.Values)
            {
                if(empleado.Departamento == (Departamento)depIndex)
                {
                    empleadosEnDepartamento = true;
                    break;
                }
            }

            if (empleadosEnDepartamento)
            {
                Console.WriteLine($"La lista de empleados de {(Departamento)depIndex}:");
                foreach (var empleado in Empleados.Values)
                {
                    if (empleado.Departamento == (Departamento)depIndex)
                    {
                        Console.WriteLine(empleado);
                    }
                }
            }
            else
            {
                Console.WriteLine("No hay empleados en este departamento");
            }
        }

        public static void AgregarEmpleado()
        {
            int id, edad, deptIndex;
            string nombre = null!;
            bool validacion = false;
            Departamento departamento = Departamento.RecursosHumanos;
            do
            {
                Console.Write("Ingrese el id del empleado: ");
                validacion = int.TryParse(Console.ReadLine(), out id);
                if (!validacion) { Console.WriteLine("El dato no es de tipo entero."); }
            }
            while (!validacion);
            validacion = false;

            do
            {
                Console.Write("Ingrese el nombre del empleado: ");
                nombre = Console.ReadLine();
                if (string.IsNullOrEmpty(nombre)) 
                { 
                    Console.WriteLine("El nombre no puede estar vacío.");
                }
                else{validacion = true;}
            }
            while (!validacion);
            validacion = false;

            do
            {
                Console.Write("Ingrese la edad del empleado: ");
                validacion = int.TryParse(Console.ReadLine(), out edad);
                if (!validacion) { Console.WriteLine("El dato no es de tipo entero."); }
            }
            while (!validacion);
            validacion = false;

            do
            {
                Console.WriteLine("Seleccione el departamento del empleado");
                foreach (var dept in Enum.GetValues(typeof(Departamento)))
                {
                    Console.WriteLine($"{(int)dept}. {dept}");
                }

                validacion = int.TryParse(Console.ReadLine(), out deptIndex);
                if (!validacion) { Console.WriteLine("El dato no es de tipo entero."); }
                else
                {
                    departamento = (Departamento)deptIndex;
                }

            }
            while (!validacion);

            Empleado empleado = new Empleado(id, nombre, edad, departamento);
            Empleados.Add(id, empleado);
            GuardarEmpleado(empleado);
            Console.WriteLine("Empleado agregado!");
        }

        public static void ActualizarEmpleado()
        {
            Console.WriteLine("Ingrese el ID del empleado a modificar");
            int id = int.Parse(Console.ReadLine());

            if (!Empleados.ContainsKey(id))
            {
                Console.WriteLine($"El empleado con ID {id} no se encontro.");
                return;
            }

            Empleado emp = Empleados[id];
            Console.WriteLine("Pulse 'enter' para omitir.");

            Console.Write("Ingrese el nombre a modificar: ");
            var nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                emp.Nombre = nombre;
            }

            Console.Write("Ingrese la edad a modificar: ");
            var edad = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                emp.Edad = int.Parse(edad);
            }

            Console.WriteLine("Seleccione el departamento a modificar: ");
            foreach (var dept in Enum.GetValues(typeof(Departamento)))
            {
                Console.WriteLine($"{(int)dept}. {dept}");
            }
            var deptIndex = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(deptIndex))
            {
                emp.Departamento = (Departamento)int.Parse(deptIndex);
            }

            Console.WriteLine("Empleado modificado!");
            GuardarDatos();
        }

        public static void EliminarEmpleado()
        {
            Console.WriteLine("Ingrese el ID del empleado a eliminar");
            int id = int.Parse(Console.ReadLine());

            if (!Empleados.Remove(id))
            {
                Console.WriteLine($"El empleado con ID {id} no se encontro.");
                return;
            }

            Console.WriteLine("Empleado Eliminado");
            GuardarDatos();
        }

        static void GuardarEmpleado(Empleado empleado)
        {
            using StreamWriter writer = new StreamWriter(ArchivoEmpleados, true);
            writer.WriteLine(empleado);
        }

        static void GuardarDatos()
        {
            using StreamWriter writer = new StreamWriter(ArchivoEmpleados);
            foreach (var empleado in Empleados.Values)
            {
                writer.WriteLine(empleado);
            }
        }

        public static void CargarDatos()
        {
            if (File.Exists(ArchivoEmpleados))
            {
                foreach(var linea in File.ReadAllLines(ArchivoEmpleados))
                {
                    string[] partes = linea.Split(", ");
                    int id = int.Parse(partes[0]);
                    string nombre = partes[1];
                    int edad = int.Parse(partes[2]);
                    Departamento departamento = (Departamento)Enum.Parse(typeof(Departamento), partes[3]);

                    Empleado empleado = new Empleado(id, nombre, edad, departamento);
                    Empleados.Add(id, empleado);
                }
                Console.WriteLine("Datos guardados correctamente");
            }
        }
    }
}
