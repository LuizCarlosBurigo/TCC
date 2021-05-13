using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.Validacao.ObjetoValor;
using CSBHService.Dominio.Commands;
using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Validacao.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;

namespace CSBHService.Dominio.Handlers
{
    public class LojaHandler : Handler<GravarLojaCommand>
    {
        private readonly ILojaRepositorio _lojaRepositorio;

        public LojaHandler(ILojaRepositorio lojaRepositorio)
        {
            _lojaRepositorio = lojaRepositorio;
        }

        public override ICommandResult Handle(GravarLojaCommand command)
        {
            //Fail Fast Validations
            if (!command.Validador())
            {
                return new CommandResult(false, "Mensagem inválida", command.Mensagem);
            }

            //Validar VOs
            DescricaoEnderecoValicado validadorEndereco = new DescricaoEnderecoValicado();
            var resultado = validadorEndereco.Validate(command.Endereco);
            if (!resultado.IsValid)
            {
                var erros = retornoMensagemErro(resultado.Errors);
                return new CommandResult(false, erros, command.Mensagem);
            }

            //Gerar Loja
            var loja = new Loja(command.CodigoEmpresa,
                                command.CodigoFilial,
                                command.Cnpj,
                                command.Endereco);
            loja.TimeStamp = command.TimeStamp;

            //Validar Loja
            LojaValidacao validadorLoja = new LojaValidacao();
            resultado = validadorLoja.Validate(loja);
            if (!resultado.IsValid)
            {
                var erros = retornoMensagemErro(resultado.Errors);
                return new CommandResult(false, erros, command.Mensagem);
            }

            //Salvar informações
            try
            {
                _lojaRepositorio.InseririOuAtualizar(loja);
                return new CommandResult(true, "Mensagem persistida com sucesso");
            }
            catch
            {
                return new CommandResult(false, "Ocorreu um erro interno no sistema", command.Mensagem);
            }
        }
    }
}
