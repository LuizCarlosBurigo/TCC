using CSBHService.Dominio.Interfaces.Servico;
using CSBHService.Dominio.ModelosMensagem;
using CSBHService.Dominio.ObjetoValor;
using MassTransit;
using System.Threading.Tasks;

namespace CSBHService.Infra.Consumidores
{
    public class FornecedorConsumidor : IConsumer<FornecedorMensagem>
    {
        private readonly IFornecedorServico _fornecedorServico;

        public FornecedorConsumidor(IFornecedorServico fornecedorServico)
        {
            _fornecedorServico = fornecedorServico;
        }

        public async Task Consume(ConsumeContext<FornecedorMensagem> context)
        {
            MensagemConsumo mensagemRabbit = new MensagemConsumo(context.Message.TimeStamp,
                                                                 context.Message.Arquivo,
                                                                 context.Message.Acao,
                                                                 context.Message.Fornecedor);
            await _fornecedorServico.processo(mensagemRabbit);
        }
    }

}
