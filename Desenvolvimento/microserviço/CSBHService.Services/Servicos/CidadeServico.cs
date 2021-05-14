using CSBHService.Dominio.Commands;
using CSBHService.Dominio.Handlers;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Dominio.Interfaces.Servico;
using CSBHService.Dominio.ModelosMensagem;
using CSBHService.Dominio.ObjetoValor;
using System.Threading.Tasks;

namespace CSBHService.Servicos.Servicos
{
    public class CidadeServico : ICidadeServico
    {
        private readonly ICidadeRepositorio _cidadeRepositorio; 

        public CidadeServico(ICidadeRepositorio cidadeRepositorio)
        {
            _cidadeRepositorio = cidadeRepositorio;
        }

        public async Task processo(MensagemConsumo mensagemRabbit)
        {
            var comando = new GravarCidadeCommand(mensagemRabbit);
            var handler = new CidadeHandler(_cidadeRepositorio);
            CommandResult command = (CommandResult)handler.Handle(comando); 
        }

    }
}
