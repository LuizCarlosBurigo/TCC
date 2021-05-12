using CSBHService.Dominio.Commands;
using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.Validacao.Entidades;
using CSBHService.Dominio.Validacao.ObjetoValor;

namespace CSBHService.Dominio.Handlers
{
    public class FornecedorHandler : Handler<GravarFornecedorCommand>
    {
        public override ICommandResult Handle(GravarFornecedorCommand command)
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

            //Gerar Fornecedor
            var fornecedor = new Fornecedor(command.CodigoFornecedor,
                                            command.DescricaoFornecedor,
                                            command.Cnpj,
                                            command.Endereco);
            fornecedor.Email = command.Email;

            //Validar Fornecedor
            FornecedorValidacao validadorFornecedor = new FornecedorValidacao();
            resultado = validadorFornecedor.Validate(fornecedor);
            if (resultado.IsValid)
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
