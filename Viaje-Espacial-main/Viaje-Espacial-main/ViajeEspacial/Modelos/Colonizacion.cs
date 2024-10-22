using ViajeEspacial.Enums;

namespace ViajeEspacial.Modelos
{
    public class Colonizacion : Mision
    {
        private int _colonos;

        public int Colonos => _colonos;
        public Colonizacion(string nombre, Destino destinoMision, int cantidadAstronautas, int colonos) : base(nombre, destinoMision, cantidadAstronautas)
        {
            _colonos = colonos;
        }

        public override double CalcularDuracion()
        {
            return CantidadAstronautas * 1.5 + (int)DestinoMision * 2;
        }

        public override string ToString()
        {
            return $"{GetType().Name}, {Nombre}, {DestinoMision}, {CantidadAstronautas}, {Colonos}";
        }
    }
}
