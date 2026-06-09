using SistemaMonitoramentoAmbiental.Enums;
using SistemaMonitoramentoAmbiental.Interfaces;
using SistemaMonitoramentoAmbiental.Models;
using SistemaMonitoramentoAmbiental.Structs;

namespace SistemaMonitoramentoAmbiental.Services
{
    public class AnalisadorAmbiental : IAnalisadorAmbiental
    {
        private static readonly Random _random = new();

        public Alerta? Analisar(DadoSensor dado)
        {
            var coord = new Coordenada(
                _random.NextDouble() * -10,
                _random.NextDouble() * -50
            );

            var conteudo = dado.Conteudo;

            if (conteudo.Contains("desmatamento", StringComparison.OrdinalIgnoreCase))
                return new Alerta("Desmatamento detectado!", NivelAlerta.Alto, coord);

            if (conteudo.Contains("temperatura", StringComparison.OrdinalIgnoreCase))
                return new Alerta("Risco de incendio!", NivelAlerta.Medio, coord);

            if (conteudo.Contains("fumaça", StringComparison.OrdinalIgnoreCase) ||
                conteudo.Contains("fumaca", StringComparison.OrdinalIgnoreCase))
                return new Alerta("Queimada em andamento!", NivelAlerta.Critico, coord);

            if (conteudo.Contains("garimpo", StringComparison.OrdinalIgnoreCase))
                return new Alerta("Garimpo ilegal detectado!", NivelAlerta.Alto, coord);

            return null;
        }
    }
}