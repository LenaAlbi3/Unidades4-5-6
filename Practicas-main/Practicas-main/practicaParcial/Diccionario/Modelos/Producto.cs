namespace Diccionario.Modelos
{
    public class Producto
    {
        private int _codigo;
        private string _nombre;

        public int Codigo => _codigo;
        public string Nombre => _nombre;

        public Producto(int codigo, string nombre)
        {
            _codigo = codigo;
            _nombre = nombre;
        }

        public override string ToString()
        {
            return $"{Codigo}-{Nombre}";
        }

        public string MostrarDatos()
        {
            return $"Código del producto: {Codigo}, {Nombre}";
        }
    }
}
