using ViajeEspacial.Enums;

namespace ViajeEspacial.Modelos
{
    public abstract class Mision
    {
        private string _nombre;
        private Destino _destinoMision;
        private int _cantidadAstronautas;

        public string Nombre => _nombre;
        public Destino DestinoMision => _destinoMision;
        public int CantidadAstronautas => _cantidadAstronautas;

        public Mision(string nombre, Destino destinoMision, int cantidadAstronautas)
        {
            _nombre = nombre;
            _destinoMision = destinoMision;
            _cantidadAstronautas = cantidadAstronautas;
        }

        public abstract double CalcularDuracion();
        public abstract override string ToString();
    }
}
