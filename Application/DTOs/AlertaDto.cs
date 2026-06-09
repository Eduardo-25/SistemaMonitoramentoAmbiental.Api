namespace SistemaMonitoramentoAmbiental.DTOs
{
    public class AlertaDto
    {
        public string Mensagem { get; set; } = string.Empty;
        public string Nivel { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Regiao { get; set; } = string.Empty;
        public DateTime DataGeracao { get; set; }
    }
}