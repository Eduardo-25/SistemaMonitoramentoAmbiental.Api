using SistemaMonitoramentoAmbiental.DTOs;
using SistemaMonitoramentoAmbiental.Enums;
using SistemaMonitoramentoAmbiental.Infrastructure.Data;
using SistemaMonitoramentoAmbiental.Infrastructure.Repositories;
using SistemaMonitoramentoAmbiental.Interfaces;
using SistemaMonitoramentoAmbiental.Models;
using SistemaMonitoramentoAmbiental.Structs;

namespace SistemaMonitoramentoAmbiental.Services
{
    public class ProcessamentoAmbientalService
    {
        private readonly IAnalisadorAmbiental _analisador;
        private readonly IAlertaRepository _repositorio;

        public ProcessamentoAmbientalService(IAnalisadorAmbiental analisador, IAlertaRepository repositorio)
        {
            _analisador = analisador;
            _repositorio = repositorio;
        }

        public async Task<ExecutarMonitoramentoResponseDto> ExecutarAsync(CancellationToken cancellationToken = default)
        {
            var satelite = new Satelite("Satélite Ambiental");

            satelite.AdicionarSensor(new SensorImagem());
            satelite.AdicionarSensor(new SensorTemperatura());
            satelite.AdicionarSensor(new SensorFumaca());
            satelite.AdicionarSensor(new SensorGarimpo());

            var dados = satelite.ColetarDados();
            var alertasDto = new List<AlertaDto>();

            foreach (var dado in dados)
            {
                try
                {
                    var alerta = _analisador.Analisar(dado);

                    if (alerta is null)
                        continue;

                    var regiao = DescobrirRegiao(alerta.Localizacao);

                    var registro = new AlertaRegistro
                    {
                        Mensagem = alerta.Mensagem,
                        Nivel = alerta.Nivel.ToString(),
                        Latitude = alerta.Localizacao.Latitude,
                        Longitude = alerta.Localizacao.Longitude,
                        Regiao = regiao,
                        DataGeracao = alerta.DataGeracao
                    };

                    await _repositorio.AdicionarAsync(registro, cancellationToken);

                    alertasDto.Add(new AlertaDto
                    {
                        Mensagem = alerta.Mensagem,
                        Nivel = alerta.Nivel.ToString(),
                        Latitude = alerta.Localizacao.Latitude,
                        Longitude = alerta.Localizacao.Longitude,
                        Regiao = regiao,
                        DataGeracao = alerta.DataGeracao
                    });
                }
                catch (Exception)
                {
                    // Em projeto acadêmico, o objetivo aqui é evitar quebra abrupta.
                }
            }

            return new ExecutarMonitoramentoResponseDto
            {
                DataExecucao = DateTime.UtcNow,
                TotalDadosColetados = dados.Count,
                TotalAlertasGerados = alertasDto.Count,
                Alertas = alertasDto
            };
        }

        private static string DescobrirRegiao(Coordenada coord)
        {
            if (coord.Latitude < -5)
                return "Amazonas";

            if (coord.Latitude >= -5 && coord.Latitude < -2)
                return "Mato Grosso";

            if (coord.Latitude >= -2)
                return "Sao Paulo";

            return "Regiao desconhecida";
        }
    }
}