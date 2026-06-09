namespace SistemaMonitoramentoAmbiental.Models
{
    public class SensorFumaca : Sensor
    {
        public SensorFumaca()
        {
            Tipo = "Fumaca";
        }

        public override DadoSensor Coletar()
        {
            return new DadoSensor("fumaca detectada");
        }
    }
}