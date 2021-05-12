using CSBHService.Dominio.Commands;
using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.Validacao.Entidades;

namespace CSBHService.Dominio.Handlers
{
    public class CidadeHandler : Handler<GravarCidadeCommand>
    {
        public override ICommandResult Handle(GravarCidadeCommand command)
        {
            //Fail Fast Validations
            if (!command.Validador())
            {
                return new CommandResult(false, "Mensagem inválida", command.Mensagem);
            }

            //Gerar Cidade
            var cidade = new Cidade(command.CodigoCidade,
                                    command.Uf,
                                    command.DescricaoCidade);
            cidade.TimeStamp = command.TimeStamp;
            //Validar Cidade
            CidadeValidacao validador = new CidadeValidacao();
            var resultado = validador.Validate(cidade);
            if (!resultado.IsValid)
            {
                var erros = retornoMensagemErro(resultado.Errors);
                return new CommandResult(false, erros, command.Mensagem);
            }

            //Salvar informações
            //Implementar
            //Retornar informações
            return new CommandResult(true, "Mensagem persistida com sucesso");
        }

    }
}
