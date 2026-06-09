namespace SistemaMonitoramentoAmbiental.Structs
{
    public readonly struct Coordenada
    {
        public double Latitude { get; }
        public double Longitude { get; }

        public Coordenada(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}