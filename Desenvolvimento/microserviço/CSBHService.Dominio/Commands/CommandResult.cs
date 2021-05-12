using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.ObjetoValor;

namespace CSBHService.Dominio.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {

        }

        public CommandResult(bool sucesso, string mensagem, MensagemConsumo objetoRecebido = null)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            ObjetoRecebido = objetoRecebido;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public MensagemConsumo ObjetoRecebido { get; set; }
    }
}