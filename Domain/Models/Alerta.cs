using SistemaMonitoramentoAmbiental.Enums;
using SistemaMonitoramentoAmbiental.Structs;

namespace SistemaMonitoramentoAmbiental.Models
{
    public partial class Alerta : EntidadeBase
    {
        public string Mensagem { get; private set; }
        public NivelAlerta Nivel { get; private set; }
        public Coordenada Localizacao { get; private set; }
        public DateTime DataGeracao { get; private set; }

        public Alerta(string mensagem, NivelAlerta nivel, Coordenada localizacao)
        {
            Mensagem = mensagem;
            Nivel = nivel;
            Localizacao = localizacao;
            DataGeracao = DateTime.UtcNow;
        }

        private Alerta()
        {
            Mensagem = string.Empty;
            Nivel = NivelAlerta.Baixo;
            Localizacao = new Coordenada(0, 0);
            DataGeracao = DateTime.UtcNow;
        }
    }
}