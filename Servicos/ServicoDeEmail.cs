using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServicoEmSegundoPlano.Servicos
{
    public class ServicoDeEmail : IHostedService
    {
        // interface que nos ajuda escrever logs do nosso servico de email
        private readonly ILogger<ServicoDeEmail> _log;

        /* Variável que que vai receber o tempo de intervalo de execução e o 
           método que iremos executar em segundo plano.*/
        private Timer _configuracaoDaExecucao;
       

        public ServicoDeEmail(ILogger<ServicoDeEmail> log)
        {
            _log = log;
        }

        private void EnviarEmail(object state)
        {
            _log.LogInformation("Nosso email está sendo enviado...");
            _log.LogInformation("Email enviado com sucesso.");
        }

        // Esse aqui é o método que será chamado assim que o nosso serviço for iniciado
        public Task StartAsync(CancellationToken cancellationToken)
        {
            int milisegundos = 5000;
            int iniciarEm = 0;

            _log.LogInformation("Nosso serviço está iniciando...");
            _log.LogInformation("Serviço iniciado.");

            _configuracaoDaExecucao = new Timer(EnviarEmail, null, iniciarEm, milisegundos);

            return Task.CompletedTask; ;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
