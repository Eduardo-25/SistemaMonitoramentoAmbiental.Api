namespace SistemaMonitoramentoAmbiental.Models
{
    public class SensorTemperatura : Sensor
    {
        public SensorTemperatura()
        {
            Tipo = "Temperatura";
        }

        public override DadoSensor Coletar()
        {
            return new DadoSensor("Temperatura elevada");
        }
    }
}