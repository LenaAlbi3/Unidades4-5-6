using ViajeEspacial.Enums;

namespace ViajeEspacial.Modelos
{
    public class Investigacion : Mision
    {
        private string _campoInvestigacion;

        public string CampoInvestigacion => _campoInvestigacion;
        public Investigacion(string nombre, Destino destinoMision, int cantidadAstronautas, string campoInvestigacion) : base(nombre, destinoMision, cantidadAstronautas)
        {
            _campoInvestigacion = campoInvestigacion;
        }

        public override double CalcularDuracion()
        {
            return CantidadAstronautas * 1.5 + (int)DestinoMision * 2;
        }

        public override string ToString()
        {
            return $"{GetType().Name}, {Nombre}, {DestinoMision}, {CantidadAstronautas}, {CampoInvestigacion}";
        }
    }
}
