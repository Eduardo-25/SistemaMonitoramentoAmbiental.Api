using Microsoft.AspNetCore.Mvc;
using SistemaMonitoramentoAmbiental.DTOs;
using SistemaMonitoramentoAmbiental.Infrastructure.Repositories;
using SistemaMonitoramentoAmbiental.Services;

namespace SistemaMonitoramentoAmbiental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitoramentoController : ControllerBase
    {
        private readonly ProcessamentoAmbientalService _servico;
        private readonly IAlertaRepository _repositorio;

        public MonitoramentoController(ProcessamentoAmbientalService servico, IAlertaRepository repositorio)
        {
            _servico = servico;
            _repositorio = repositorio;
        }

        [HttpPost("executar")]
        public async Task<ActionResult<ExecutarMonitoramentoResponseDto>> Executar(CancellationToken cancellationToken)
        {
            var resultado = await _servico.ExecutarAsync(cancellationToken);
            return Ok(resultado);
        }

        [HttpGet("alertas")]
        public async Task<ActionResult<IEnumerable<AlertaDto>>> ObterAlertas(CancellationToken cancellationToken)
        {
            var alertas = await _repositorio.ObterTodosAsync(cancellationToken);

            var dto = alertas.Select(a => new AlertaDto
            {
                Mensagem = a.Mensagem,
                Nivel = a.Nivel,
                Latitude = a.Latitude,
                Longitude = a.Longitude,
                Regiao = a.Regiao,
                DataGeracao = a.DataGeracao
            });

            return Ok(dto);
        }
    }
}