using CSBHService.Dominio.Interfaces.Commands;
using FluentValidation.Results;
using System.Collections.Generic;

namespace CSBHService.Dominio.Handlers
{
    public abstract class Handler<TCommand> 
        where TCommand: ICommand
    {
        public abstract ICommandResult Handle( TCommand command);

        protected string retornoMensagemErro(List<ValidationFailure> erros)
        {
            string erro = "";
            foreach(var failure in erros)
            {
                erro += " Propriedade: " + failure.PropertyName + " Erro: " + failure.ErrorMessage;
            }
            return erro;
        }
    }
}
