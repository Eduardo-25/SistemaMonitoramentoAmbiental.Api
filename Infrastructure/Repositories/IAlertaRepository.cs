using SistemaMonitoramentoAmbiental.Infrastructure.Data;

namespace SistemaMonitoramentoAmbiental.Infrastructure.Repositories
{
    public interface IAlertaRepository
    {
        Task AdicionarAsync(AlertaRegistro alerta, CancellationToken cancellationToken = default);
        Task<List<AlertaRegistro>> ObterTodosAsync(CancellationToken cancellationToken = default);
    }
}