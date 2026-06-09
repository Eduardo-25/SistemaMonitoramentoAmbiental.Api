namespace SistemaMonitoramentoAmbiental.Models
{
    public partial class Alerta
    {
        public string ObterResumo()
        {
            return $"{Nivel}: {Mensagem} em {Localizacao.Latitude:F4}, {Localizacao.Longitude:F4}";
        }
    }
}