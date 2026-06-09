using System.Linq;

namespace SistemaMonitoramentoAmbiental.Models
{
    public class Satelite : EntidadeBase
    {
        public string Nome { get; private set; }

        private readonly List<Sensor> _sensores = new();

        public IReadOnlyCollection<Sensor> Sensores => _sensores.AsReadOnly();

        public Satelite(string nome)
        {
            Nome = nome;
        }

        private Satelite()
        {
            Nome = string.Empty;
        }

        public void AdicionarSensor(Sensor sensor)
        {
            _sensores.Add(sensor);
        }

        public List<DadoSensor> ColetarDados()
        {
            List<DadoSensor> dados = new();

            foreach (var sensor in _sensores)
            {
                dados.Add(sensor.Coletar());
            }

            return dados;
        }
    }
}