namespace SistemaMonitoramentoAmbiental.Models
{
    public class SensorImagem : Sensor
    {
        public SensorImagem()
        {
            Tipo = "Imagem";
        }

        public override DadoSensor Coletar()
        {
            return new DadoSensor("Imagem com possível desmatamento");
        }
    }
}