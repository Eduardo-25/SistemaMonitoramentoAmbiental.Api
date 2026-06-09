using Microsoft.EntityFrameworkCore;
using SistemaMonitoramentoAmbiental.Infrastructure.Data;

namespace SistemaMonitoramentoAmbiental.Infrastructure.Repositories
{
    public class AlertaRepository : IAlertaRepository
    {
        private readonly AppDbContext _context;

        public AlertaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(AlertaRegistro alerta, CancellationToken cancellationToken = default)
        {
            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<AlertaRegistro>> ObterTodosAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Alertas
                .OrderByDescending(a => a.DataGeracao)
                .ToListAsync(cancellationToken);
        }
    }
}