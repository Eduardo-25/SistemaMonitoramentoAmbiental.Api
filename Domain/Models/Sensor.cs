namespace SistemaMonitoramentoAmbiental.Models
{
    public abstract class Sensor
    {
        public string Tipo { get; protected set; } = string.Empty;
        public abstract DadoSensor Coletar();
    }
}