🌍 Sistema de Monitoramento Ambiental via Satélite
Integrantes

Eduardo da Silva Lima (RM: 554804)
Estevam Melo (RM: 555124)
Enzo Bonacasatta (RM: 555372)
Guilherme Ulacco (RM: 558418)
Matheus Hostim (RM: 556517)

📌 Motivação do Projeto

O aumento de problemas ambientais como desmatamento, queimadas e garimpo ilegal tem causado impactos significativos no Brasil e no mundo. Muitas dessas atividades ocorrem em áreas remotas, o que dificulta a fiscalização e a resposta rápida das autoridades.

Este projeto foi desenvolvido para simular uma solução tecnológica capaz de trabalhar com dados orbitais e apoiar o monitoramento ambiental, utilizando conceitos de programação orientada a objetos, banco de dados e WebService.

A proposta busca demonstrar como a tecnologia pode ser aplicada na prevenção e no combate a crimes ambientais, contribuindo para a proteção do meio ambiente e para a tomada de decisão baseada em dados.

🛰️ Visão Geral da Solução

A aplicação simula o funcionamento de um sistema de monitoramento ambiental com apoio de satélites e sensores. A partir da coleta de dados simulados, o sistema realiza a análise das informações, identifica possíveis ocorrências ambientais e gera alertas com nível de risco e localização estimada.

A solução foi estruturada como uma API ASP.NET Core, com persistência em banco de dados e exposição de endpoints para execução e consulta dos alertas gerados.

🔄 Fluxo de Funcionamento
Coleta de Dados
O satélite simulado coleta informações por meio de sensores especializados, como:
Imagem
Temperatura
Fumaça
Garimpo
Análise dos Dados
Um serviço analisador interpreta os dados coletados e verifica padrões que indiquem risco ambiental.
Geração de Alertas
Quando uma ocorrência é identificada, o sistema cria um alerta com:
mensagem
nível de risco
localização
data de geração
Classificação da Região
Com base nas coordenadas geradas, o sistema simula a identificação da região afetada.
Persistência em Banco de Dados
Os alertas gerados são salvos em banco de dados para consulta posterior.
Exposição via WebService
A aplicação disponibiliza endpoints REST para executar o monitoramento e consultar os alertas registrados.
⚙️ Tecnologias e Conceitos Utilizados

O projeto aplica diversos conceitos importantes de desenvolvimento de software:

✅ C#
✅ ASP.NET Core Web API
✅ Programação Orientada a Objetos
✅ Herança e Polimorfismo
✅ Classes Abstratas
✅ Interfaces e Injeção de Dependência
✅ Tratamento de Exceções
✅ Structs
✅ DTOs
✅ Banco de Dados com SQLite
✅ Swagger para testes da API
✅ Organização em camadas
🧩 Estrutura do Projeto

A aplicação foi organizada para separar responsabilidades e facilitar manutenção e evolução:

Controllers
Responsáveis por receber requisições HTTP e expor os endpoints da API.
Domain
Contém as entidades principais do sistema, como satélite, sensores, alertas e objetos de valor.
Application
Contém os serviços de aplicação, DTOs e regras de negócio.
Infrastructure
Contém o acesso a dados, repositórios e contexto do banco de dados.
🧠 Modelagem de Domínio

A aplicação foi construída com foco em uma boa modelagem do domínio, utilizando entidades e abstrações para representar o cenário do projeto.

Principais entidades e componentes
Satelite
Representa o satélite responsável pela coleta dos dados.
Sensor
Classe abstrata base para os sensores da solução.
SensorImagem
Simula detecção de desmatamento por imagem.
SensorTemperatura
Simula risco de incêndio por aumento de temperatura.
SensorFumaca
Simula queimadas em andamento.
SensorGarimpo
Simula atividades de garimpo ilegal.
DadoSensor
Representa o dado coletado por um sensor.
Alerta
Representa o alerta gerado após a análise dos dados.
Coordenada
Estrutura auxiliar utilizada para representar localização geográfica.
🧪 Funcionalidades da API

A API disponibiliza endpoints para:

executar o processo de monitoramento ambiental;
gerar alertas automaticamente;
salvar os alertas no banco de dados;
consultar o histórico de alertas.
Endpoints principais
POST /api/Monitoramento/executar
Executa a simulação de coleta e análise dos dados ambientais.
GET /api/Monitoramento/alertas
Retorna os alertas salvos no banco de dados.
🗃️ Banco de Dados

A persistência foi implementada com SQLite, para armazenar os alertas gerados durante a execução da aplicação.

Os dados salvos incluem:

mensagem do alerta;
nível de risco;
latitude;
longitude;
região estimada;
data de geração.

Isso permite manter histórico e consultar os eventos já processados pelo sistema.

🔐 Tratamento de Erros e Segurança

A aplicação possui tratamento básico de exceções para evitar falhas inesperadas durante a execução.

A ideia é representar um cenário em que um sistema crítico não deve parar abruptamente ao encontrar dados inconsistentes ou falhas de processamento.

Além disso, a separação entre domínio, aplicação, infraestrutura e API ajuda na organização, segurança e manutenção da solução.

🚀 Como Executar o Projeto
Pré-requisitos
.NET SDK instalado
Banco SQLite disponível localmente
Ambiente compatível com ASP.NET Core
Passos
Restaurar os pacotes:
dotnet restore
Compilar o projeto:
dotnet build
Executar a aplicação:
dotnet run
Abrir o Swagger no navegador:
http://localhost:PORTA/swagger

🚨 Tipos de Alertas Detectados

O sistema atualmente identifica os seguintes cenários:

🌳 Desmatamento detectado
🔥 Risco de incêndio
💨 Queimada em andamento
⛏️ Garimpo ilegal detectado

Cada alerta é classificado com um nível de risco, como:

Baixo
Médio
Alto
Crítico
📈 Possíveis Expansões Futuras

A solução foi pensada para ser escalável e pode evoluir com:

integração com APIs reais de dados ambientais;
uso de Inteligência Artificial para previsão de riscos;
dashboard web para visualização dos alertas;
autenticação de usuários;
relatórios automáticos;
envio de notificações em tempo real;
conexão com serviços externos de satélite.
🖼️ Prints do Projeto