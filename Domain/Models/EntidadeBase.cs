namespace SistemaMonitoramentoAmbiental.Models
{
    public abstract class EntidadeBase
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;
    }
}