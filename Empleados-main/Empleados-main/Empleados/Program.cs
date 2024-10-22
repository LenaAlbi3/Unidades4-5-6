namespace Empleados.Modelos
{
    public class Program
    {
        static void Main()
        {
            SysEmpleados.CargarDatos();

            int opcion;

            do
            {
                Console.WriteLine("======== Menú =========");
                Console.WriteLine("1. Agregar Empleado.");
                Console.WriteLine("2. Eliminar Empleado.");
                Console.WriteLine("3. Modificar Empleado.");
                Console.WriteLine("4. Mostrar Todos los Empleados.");
                Console.WriteLine("5. Mostrar Empleados por Departamento.");
                Console.WriteLine("6. Salir.\n");
                Console.Write("Opción: ");

                try
                {
                    opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            SysEmpleados.AgregarEmpleado();
                            Console.WriteLine("\n");
                            break;
                        case 2:
                            SysEmpleados.EliminarEmpleado();
                            Console.WriteLine("\n");
                            break;
                        case 3:
                            SysEmpleados.ActualizarEmpleado();
                            Console.WriteLine("\n");
                            break;
                        case 4:
                            SysEmpleados.MostrarEmpleados();
                            Console.WriteLine("\n");
                            break;
                        case 5:
                            SysEmpleados.MostrarEmpleadosPorDepartamento();
                            Console.WriteLine("\n");
                            break;
                        case 6:
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Ingrese una opción válida.\n");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}\n");
                    opcion = 0;
                }

            } while (opcion != 6);
        }
    }
}
