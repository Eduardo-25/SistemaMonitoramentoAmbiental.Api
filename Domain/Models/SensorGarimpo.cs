namespace SistemaMonitoramentoAmbiental.Models
{
    public class SensorGarimpo : Sensor
    {
        public SensorGarimpo()
        {
            Tipo = "Garimpo";
        }

        public override DadoSensor Coletar()
        {
            return new DadoSensor("garimpo ilegal detectado");
        }
    }
}