using CSBHService.Dominio.Interfaces.Servico;
using CSBHService.Dominio.ModelosMensagem;
using CSBHService.Dominio.ObjetoValor;
using MassTransit;
using System.Threading.Tasks;

namespace CSBHService.Infra.Consumidores
{
    class LojaConsumidor : IConsumer<LojaMensagem>
    {
        private readonly ILojaServico _lojaServico;

        public LojaConsumidor(ILojaServico lojaServico)
        {
            _lojaServico = lojaServico;
        }

        public async Task Consume(ConsumeContext<LojaMensagem> context)
        {
            MensagemConsumo mensagemRabbit = new MensagemConsumo(context.Message.TimeStamp,
                                                                 context.Message.Arquivo,
                                                                 context.Message.Acao,
                                                                 context.Message.Loja);
            await _lojaServico.processo(mensagemRabbit);
        }
    }
}
