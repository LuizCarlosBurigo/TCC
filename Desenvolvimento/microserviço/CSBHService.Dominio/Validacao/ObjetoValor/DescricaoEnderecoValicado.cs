using FluentValidation;
using CSBHService.Dominio.ObjetoValor;
using System.Threading.Tasks;
using System.Collections;

namespace CSBHService.Dominio.Validacao.ObjetoValor
{
    public class DescricaoEnderecoValicado : AbstractValidator<DescricaoEndereco>

    {
        public DescricaoEnderecoValicado()
        {
            RuleFor(x => x.Bairro)
                .NotNull()
                .NotEmpty().WithMessage("Nome Bairro Inválido")
                .MinimumLength(3)
                .MaximumLength(80).WithMessage("Nome Bairro deve possuir entre 3 a 80 caracteres");

            RuleFor(x => x.CodigoCidade)
                .GreaterThan(0)
                .WithMessage("Código Cidade Inválido");

            RuleFor(x => x.Cep)
                .MinimumLength(8)
                .MaximumLength(8)
                .WithMessage("Número CEP inválido");

            RuleFor(x => x.Endereco)
                .MinimumLength(5)
                .MaximumLength(80)
                .WithMessage("Descrição Endereço inválida");

            RuleFor(x => x.Numero)
                .GreaterThan(0)
                .WithMessage("Numero inválido");

        }
    }
}
