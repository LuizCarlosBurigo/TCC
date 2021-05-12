using CSBHService.Dominio.Commands;
using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.Validacao.Entidades;

namespace CSBHService.Dominio.Handlers
{
    public class EntradaHandler : Handler<GravarEntradaCommand>
    {
        public override ICommandResult Handle(GravarEntradaCommand command)
        {
            //Fail Fast Validations
            if (!command.Validador())
            {
                return new CommandResult(false, "Mensagem inválida", command.Mensagem);
            }

            //Gerar Entrada
            var entrada = new Entrada(command.CodigoEmpresa,
                                      command.CodigoFilial,
                                      command.CodigoEntrada,
                                      command.CodigoTransportadora);
            entrada.TimeStamp = command.TimeStamp;
            entrada.DataPedido = command.DataPedido;
            entrada.EntradaPedido = command.EntradaPedido;
            entrada.Total = command.Total;
            entrada.Frete = command.Frete;
            entrada.NumeroNotaFiscal = command.NumeroNotaFiscal;
            entrada.SerieNotaFiscal = command.SerieNotaFiscal;

            //Validar Entrada
            EntradaValidacao validador = new EntradaValidacao();
            var resultado = validador.Validate(entrada);
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
