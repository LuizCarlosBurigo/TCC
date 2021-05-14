using CSBHService.Dominio.Interfaces.Servico;
using CSBHService.Dominio.ModelosMensagem;
using CSBHService.Dominio.ObjetoValor;
using MassTransit;
using System.Threading.Tasks;

namespace CSBHService.Infra.Consumidores
{
    public class SaidaConsumidor : IConsumer<SaidaMensagem>
    {
        private readonly ISaidaServico _saidaServico;

        public SaidaConsumidor(ISaidaServico saidaServico)
        {
            _saidaServico = saidaServico;
        }

        public async Task Consume(ConsumeContext<SaidaMensagem> context)
        {
            MensagemConsumo mensagemRabbit = new MensagemConsumo(context.Message.TimeStamp,
                                                                 context.Message.Arquivo,
                                                                 context.Message.Acao,
                                                                 context.Message.Saida);
            await _saidaServico.processo(mensagemRabbit);
        }
    }
}
