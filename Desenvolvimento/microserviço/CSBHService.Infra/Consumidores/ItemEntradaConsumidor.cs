using CSBHService.Dominio.Interfaces.Servico;
using CSBHService.Dominio.ModelosMensagem;
using CSBHService.Dominio.ObjetoValor;
using MassTransit;
using System.Threading.Tasks;

namespace CSBHService.Infra.Consumidores
{
    public class ItemEntradaConsumidor : IConsumer<ItemEntradaMensagem>
    {
        private readonly IItemEntradaServico _itemEntradaServico;

        public ItemEntradaConsumidor(IItemEntradaServico entradaServico)
        {
            _itemEntradaServico = entradaServico;
        }

        public async Task Consume(ConsumeContext<ItemEntradaMensagem> context)
        {
            MensagemConsumo mensagemRabbit = new MensagemConsumo(context.Message.TimeStamp,
                                                                 context.Message.Arquivo,
                                                                 context.Message.Acao,
                                                                 context.Message.ItemEntrada);
            await _itemEntradaServico.processo(mensagemRabbit);
        }
    }
}
