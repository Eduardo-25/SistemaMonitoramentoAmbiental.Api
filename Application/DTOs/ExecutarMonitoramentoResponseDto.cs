namespace SistemaMonitoramentoAmbiental.DTOs
{
    public class ExecutarMonitoramentoResponseDto
    {
        public DateTime DataExecucao { get; set; } = DateTime.UtcNow;
        public int TotalDadosColetados { get; set; }
        public int TotalAlertasGerados { get; set; }
        public List<AlertaDto> Alertas { get; set; } = new();
    }
}