using CSBHService.Dominio.Commands;
using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Dominio.Validacao.Entidades;

namespace CSBHService.Dominio.Handlers
{
    public class CidadeHandler : Handler<GravarCidadeCommand>
    {
        private readonly ICidadeRepositorio _cidadeRepositorio;

        public CidadeHandler(ICidadeRepositorio cidadeRepositorio)
        {
            _cidadeRepositorio = cidadeRepositorio;
        }

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
            try
            {
                 _cidadeRepositorio.InseririOuAtualizar(cidade);
                return new CommandResult(true, "Mensagem persistida com sucesso");
            }
            catch
            {
                return new CommandResult(false, "Ocorreu um erro interno no sistema", command.Mensagem);
            }
        }

    }
}
