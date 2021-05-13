using CSBHService.Dominio.Commands;
using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Dominio.Validacao.Entidades;

namespace CSBHService.Dominio.Handlers
{
    public class ItemEntradaHandler : Handler<GravarItemEntradaCommand>
    {
        private readonly IItemEntradaRepositorio _itemEntradaRepositorio;

        public ItemEntradaHandler(IItemEntradaRepositorio itemEntradaRepositorio)
        {
            _itemEntradaRepositorio = itemEntradaRepositorio;
        }

        public override ICommandResult Handle(GravarItemEntradaCommand command)
        {
            //Fail Fast Validations
            if (!command.Validador())
            {
                return new CommandResult(false, "Mensagem inválida", command.Mensagem);
            }

            //Gerar Item Entrada
            var itemEntrada = new ItemEntrada(command.CodigoEmpresa,
                                              command.CodigoFilial,
                                              command.CodigoEntrada,
                                              command.CodigoProduto,
                                              command.Sequencia);
            itemEntrada.TimeStamp = command.TimeStamp;
            itemEntrada.Lote = command.Lote;
            itemEntrada.Quantidade = command.Quantidade;
            itemEntrada.Frete = command.Frete;

            //Validar Item Entrada
            ItemEntradaValidacao validador = new ItemEntradaValidacao();
            var resultado = validador.Validate(itemEntrada);
            if (!resultado.IsValid)
            {
                var erros = retornoMensagemErro(resultado.Errors);
                return new CommandResult(false, erros, command.Mensagem);
            }

            //Salvar informações
            try
            {
                _itemEntradaRepositorio.InseririOuAtualizar(itemEntrada);
                return new CommandResult(true, "Mensagem persistida com sucesso");
            }
            catch
            {
                return new CommandResult(false, "Ocorreu um erro interno no sistema", command.Mensagem);
            }
        }
    }
}
