using CSBHService.Dominio.Interfaces.Servico;
using CSBHService.Dominio.ModelosMensagem;
using CSBHService.Dominio.ObjetoValor;
using MassTransit;
using System.Threading.Tasks;

namespace CSBHService.Infra.Consumidores
{
    public class ItemSaidaConsumidor : IConsumer<ItemSaidaMensagem>
    {
        private readonly IItemSaidaServico _itemSaidaServico;

        public ItemSaidaConsumidor(IItemSaidaServico saidaServico)
        {
            _itemSaidaServico = saidaServico;
        }

        public async Task Consume(ConsumeContext<ItemSaidaMensagem> context)
        {
            MensagemConsumo mensagemRabbit = new MensagemConsumo(context.Message.TimeStamp,
                                                                 context.Message.Arquivo,
                                                                 context.Message.Acao,
                                                                 context.Message.ItemSaida);
            await _itemSaidaServico.processo(mensagemRabbit);
        }
    }
}
