using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.Commands;
using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Validacao.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;

namespace CSBHService.Dominio.Handlers
{
    public class ProdutoHandler : Handler<GravarProdutoCommand>
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoHandler(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public override ICommandResult Handle(GravarProdutoCommand command)
        {
            //Fail Fast Validations
            if (!command.Validador())
            {
                return new CommandResult(false, "Mensagem inválida", command.Mensagem);
            }

            //Gerar Produto
            var produto = new Produto(command.CodigoEmpresa,
                                      command.CodigoFilial,
                                      command.CodigoEntrada,
                                      command.CodigoProduto,
                                      command.Sequencia);
            produto.TimeStamp = command.TimeStamp;
            produto.Lote = command.Lote;
            produto.Quantidade = command.Quantidade;
            produto.Valor = command.Valor;

            //Validar Produto
            ProdutoValidacao validadorProduto = new ProdutoValidacao();
            var resultado = validadorProduto.Validate(produto);
            if (!resultado.IsValid)
            {
                var erros = retornoMensagemErro(resultado.Errors);
                return new CommandResult(false, erros, command.Mensagem);
            }

            //Salvar informações
            try
            {
                _produtoRepositorio.InseririOuAtualizar(produto);
                return new CommandResult(true, "Mensagem persistida com sucesso");
            }
            catch
            {
                return new CommandResult(false, "Ocorreu um erro interno no sistema", command.Mensagem);
            }
        }
    }
}
