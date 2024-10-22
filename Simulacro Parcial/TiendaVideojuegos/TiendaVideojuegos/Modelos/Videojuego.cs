using TiendaVideojuegos.Enums;

namespace TiendaVideojuegos.Modelos
{
    public class Videojuego
    {
        private string _nombre;
        private Plataforma _plataforma;
        private double _precio;
        private int _cantidad;

        public string Nombre => _nombre;
        public Plataforma Plataforma => _plataforma;
        public double Precio => _precio;
        public int Cantidad => _cantidad;

        public Videojuego(string nombre, Plataforma plataforma, double precio, int cantidad)
        {
            _nombre = nombre;
            _plataforma = plataforma;
            _precio = precio;
            _cantidad = cantidad;
        }

        public override string ToString()
        {
            return $"{Nombre}-{Plataforma}-{Precio}-{Cantidad}";
        }
    }
}
