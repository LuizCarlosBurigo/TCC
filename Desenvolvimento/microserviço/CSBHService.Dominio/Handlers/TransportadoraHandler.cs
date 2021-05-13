using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.Validacao.ObjetoValor;
using CSBHService.Dominio.Commands;
using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Validacao.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;

namespace CSBHService.Dominio.Handlers
{
    public class TransportadoraHandler : Handler<GravarTransportadoraCommand>
    {

        private readonly ITransportadoraRepositorio _transportadoraRepositorio;

        public TransportadoraHandler(ITransportadoraRepositorio transportadoraRepositorio)
        {
            _transportadoraRepositorio = transportadoraRepositorio;
        }

        public override ICommandResult Handle(GravarTransportadoraCommand command)
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
            var transportadora = new Transportadora(command.CodigoTransportadora,
                                                    command.DescricaoTransportadora,
                                                    command.Cnpj,
                                                    command.Email,
                                                    command.Endereco);

            //Validar Transportadora
            TransportadoraValidacao validadorTransportadora = new TransportadoraValidacao();
            resultado = validadorTransportadora.Validate(transportadora);
            if (!resultado.IsValid)
            {
                var erros = retornoMensagemErro(resultado.Errors);
                return new CommandResult(false, erros, command.Mensagem);
            }

            //Salvar informações
            try
            {
                _transportadoraRepositorio.InseririOuAtualizar(transportadora);
                return new CommandResult(true, "Mensagem persistida com sucesso");
            }
            catch
            {
                return new CommandResult(false, "Ocorreu um erro interno no sistema", command.Mensagem);
            }
        }
    }
}
