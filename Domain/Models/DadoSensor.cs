namespace SistemaMonitoramentoAmbiental.Models
{
    public class DadoSensor
    {
        public string Conteudo { get; private set; }
        public DateTime DataColeta { get; private set; }

        public DadoSensor(string conteudo)
        {
            Conteudo = conteudo;
            DataColeta = DateTime.UtcNow;
        }

        private DadoSensor()
        {
            Conteudo = string.Empty;
            DataColeta = DateTime.UtcNow;
        }
    }
}