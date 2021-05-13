using CSBHService.Dominio.Commands;
using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Dominio.Validacao.Entidades;

namespace CSBHService.Dominio.Handlers
{
    public class ItemSaidaHandler : Handler<GravarItemSaidaCommand>
    {
        private readonly IItemSaidaRepositorio _itemSaidaRepositorio;

        public ItemSaidaHandler(IItemSaidaRepositorio itemSaidaRepositorio)
        {
            _itemSaidaRepositorio = itemSaidaRepositorio;
        }

        public override ICommandResult Handle(GravarItemSaidaCommand command)
        {
            //Fail Fast Validations
            if (!command.Validador())
            {
                return new CommandResult(false, "Mensagem inválida", command.Mensagem);
            }

            //Gerar Item Saida
            var itemSaida = new ItemSaida(command.CodigoEmpresa,
                                          command.CodigoFilial,
                                          command.CodigoSaida,
                                          command.CodigoProduto,
                                          command.Sequencia);
            itemSaida.TimeStamp = command.TimeStamp;
            itemSaida.CodigoLote = command.CodigoLote;
            itemSaida.Quantidade = command.Quantidade;
            itemSaida.Valor = command.Valor;

            //Validar ItemSaida
            ItemSaidaValidacao validador = new ItemSaidaValidacao();
            var resultado = validador.Validate(itemSaida);
            if (!resultado.IsValid)
            {
                var erros = retornoMensagemErro(resultado.Errors);
                return new CommandResult(false, erros, command.Mensagem);
            }

            //Salvar informações
            try
            {
                _itemSaidaRepositorio.InseririOuAtualizar(itemSaida);
                return new CommandResult(true, "Mensagem persistida com sucesso");
            }
            catch
            {
                return new CommandResult(false, "Ocorreu um erro interno no sistema", command.Mensagem);
            }
        }
    }
}
