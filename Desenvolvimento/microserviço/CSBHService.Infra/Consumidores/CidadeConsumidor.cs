using CSBHService.Dominio.Interfaces.Servico;
using CSBHService.Dominio.ModelosMensagem;
using CSBHService.Dominio.ObjetoValor;
using MassTransit;
using System.Threading.Tasks;

namespace CSBHService.Infra.Consumidores
{
    public class CidadeConsumidor : IConsumer<CidadeMensagem>
    {
        private readonly ICidadeServico _cidadeServico;
        public CidadeConsumidor(ICidadeServico cidadeServico)
        {
            _cidadeServico = cidadeServico;
        }

        public async Task Consume(ConsumeContext<CidadeMensagem> context)
        {
            MensagemConsumo mensagemRabbit = new MensagemConsumo(context.Message.TimeStamp,
                                                                 context.Message.Arquivo,
                                                                 context.Message.Acao,
                                                                 context.Message.Cidade);
            await _cidadeServico.processo(mensagemRabbit);
        }
    }
}
