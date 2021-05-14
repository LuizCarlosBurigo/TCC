using CSBHService.Dominio.Interfaces.Servico;
using CSBHService.Dominio.ModelosMensagem;
using CSBHService.Dominio.ObjetoValor;
using MassTransit;
using System.Threading.Tasks;

namespace CSBHService.Infra.Consumidores
{
    public class EntradaConsumidor : IConsumer<EntradaMensagem>
    {
        private readonly IEntradaServico _entradaServico;

        public EntradaConsumidor(IEntradaServico entradaServico)
        {
            _entradaServico = entradaServico;
        }

        public async Task Consume(ConsumeContext<EntradaMensagem> context)
        {
            MensagemConsumo mensagemRabbit = new MensagemConsumo(context.Message.TimeStamp,
                                                                 context.Message.Arquivo,
                                                                 context.Message.Acao,
                                                                 context.Message.Entrada);
            await _entradaServico.processo(mensagemRabbit);
        }
    }
}
