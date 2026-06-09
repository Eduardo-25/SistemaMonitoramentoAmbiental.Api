using SistemaMonitoramentoAmbiental.Models;

namespace SistemaMonitoramentoAmbiental.Interfaces
{
    public interface IAnalisadorAmbiental
    {
        Alerta? Analisar(DadoSensor dado);
    }
}