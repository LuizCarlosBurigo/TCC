using CSBHService.Dominio.Entidades;
using FluentValidation;

namespace CSBHService.Dominio.Validacao.Entidades
{
    public class FornecedorValidacao : AbstractValidator<Fornecedor>
    {
        public FornecedorValidacao()
        {
            RuleFor(x => x.CodigoFornecedor)
                .GreaterThan(0)
                .WithMessage("Codigo Fornecedor inválido");


            RuleFor(x => x.DescricaoFornecedor)
                .MinimumLength(5)
                .MaximumLength(80)
                .WithMessage("Descrição Fornecedor inválida");

            RuleFor(x => x.Cnpj)
                .Length(14)
                .WithMessage("CNPJ inválido");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Email inválido");
        }
    }
}
