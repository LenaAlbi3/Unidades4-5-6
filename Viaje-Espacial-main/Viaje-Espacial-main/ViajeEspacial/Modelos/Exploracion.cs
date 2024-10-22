using ViajeEspacial.Enums;

namespace ViajeEspacial.Modelos
{
    public class Exploracion : Mision
    {
        public Exploracion(string nombre, Destino destinoMision, int cantidadAstronautas) : base(nombre, destinoMision, cantidadAstronautas) { }

        public override double CalcularDuracion()
        {
            return CantidadAstronautas * 1.5 + (int)DestinoMision * 2;
        }

        public override string ToString()
        {
            return $"{GetType().Name}, {Nombre}, {DestinoMision}, {CantidadAstronautas}";
        }
    }
}
