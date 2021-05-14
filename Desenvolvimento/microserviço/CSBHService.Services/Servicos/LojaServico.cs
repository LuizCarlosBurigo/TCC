using CSBHService.Dominio.Commands;
using CSBHService.Dominio.Handlers;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Dominio.Interfaces.Servico;
using CSBHService.Dominio.ObjetoValor;
using System.Threading.Tasks;

namespace CSBHService.Servicos.Servicos
{
    public class LojaServico : ILojaServico
    {
        private readonly ILojaRepositorio _lojaRepositorio;

        public LojaServico(ILojaRepositorio lojaRepositorio)
        {
            _lojaRepositorio = lojaRepositorio;
        }

        public async Task processo(MensagemConsumo mensagemRabbit)
        {
            var comando = new GravarLojaCommand(mensagemRabbit);
            var handler = new LojaHandler(_lojaRepositorio);
            CommandResult command = (CommandResult)handler.Handle(comando);
        }
    }
}
