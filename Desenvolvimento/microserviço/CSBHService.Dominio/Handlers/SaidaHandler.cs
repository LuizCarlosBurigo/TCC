using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.Commands;
using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Validacao.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;

namespace CSBHService.Dominio.Handlers
{
    public class SaidaHandler : Handler<GravarSaidaCommand>
    {
        private readonly ISaidaRepositorio _saidaRepositorio;

        public SaidaHandler(ISaidaRepositorio saidaRepositorio)
        {
            _saidaRepositorio = saidaRepositorio;
        }

        public override ICommandResult Handle(GravarSaidaCommand command)
        {
            //Fail Fast Validations
            if (!command.Validador())
            {
                return new CommandResult(false, "Mensagem inválida", command.Mensagem);
            }

            //Gerar Saida
            var saida = new Saida(command.CodigoEmpresa,
                                  command.CodigoFilial,
                                  command.CodigoSaida,
                                  command.CodigoTranspotadora);
            saida.TimeStamp = command.TimeStamp;
            saida.Total = command.Total;
            saida.Frete = command.Frete;
            saida.Imposto = command.Imposto;

            //Validar Saida
            SaidaValidacao validador = new SaidaValidacao();
            var resultado = validador.Validate(saida);
            if (!resultado.IsValid)
            {
                var erros = retornoMensagemErro(resultado.Errors);
                return new CommandResult(false, erros, command.Mensagem);
            }

            //Salvar informações
            try
            {
                _saidaRepositorio.InseririOuAtualizar(saida);
                return new CommandResult(true, "Mensagem persistida com sucesso");
            }
            catch
            {
                return new CommandResult(false, "Ocorreu um erro interno no sistema", command.Mensagem);
            }
        }
    }
}
