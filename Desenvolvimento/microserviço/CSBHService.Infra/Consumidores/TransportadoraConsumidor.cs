using CSBHService.Dominio.Interfaces.Servico;
using CSBHService.Dominio.ModelosMensagem;
using CSBHService.Dominio.ObjetoValor;
using MassTransit;
using System.Threading.Tasks;

namespace CSBHService.Infra.Consumidores
{
    public class TransportadoraConsumidor : IConsumer<TransportadoraMensagem>
    {
        private readonly ITransportadoraServico _transportadoraServico;

        public TransportadoraConsumidor(ITransportadoraServico transportadoraServico)
        {
            _transportadoraServico = transportadoraServico;
        }

        public async Task Consume(ConsumeContext<TransportadoraMensagem> context)
        {
            MensagemConsumo mensagemRabbit = new MensagemConsumo(context.Message.TimeStamp,
                                                                 context.Message.Arquivo,
                                                                 context.Message.Acao,
                                                                 context.Message.Trasportadora);
            await _transportadoraServico.processo(mensagemRabbit);
        }
    }
}
