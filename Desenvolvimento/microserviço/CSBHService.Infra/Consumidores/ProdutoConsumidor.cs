using CSBHService.Dominio.Interfaces.Servico;
using CSBHService.Dominio.ModelosMensagem;
using CSBHService.Dominio.ObjetoValor;
using MassTransit;
using System.Threading.Tasks;

namespace CSBHService.Infra.Consumidores
{
    public class ProdutoConsumidor : IConsumer<ProdutoMensagem>
    {
        private readonly IProdutoServico _produtoServico;

        public ProdutoConsumidor(IProdutoServico entradaServico)
        {
            _produtoServico = entradaServico;
        }

        public async Task Consume(ConsumeContext<ProdutoMensagem> context)
        {
            MensagemConsumo mensagemRabbit = new MensagemConsumo(context.Message.TimeStamp,
                                                                 context.Message.Arquivo,
                                                                 context.Message.Acao,
                                                                 context.Message.Produto);
            await _produtoServico.processo(mensagemRabbit);
        }
    }
}
