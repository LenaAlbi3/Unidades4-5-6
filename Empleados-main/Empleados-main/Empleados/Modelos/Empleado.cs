using Empleados.Enums;

namespace Empleados.Modelos
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public Departamento Departamento { get; set; }

        public Empleado(int id, string nombre, int edad, Departamento departamento)
        {
            Id = id;
            Nombre = nombre;
            Edad = edad;
            Departamento = departamento;
        }

        public override string ToString()
        {
            return $"{Id}, {Nombre}, {Edad}, {Departamento}";
        }
    }
}
