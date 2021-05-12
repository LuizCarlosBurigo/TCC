using FluentValidation;
using CSBHService.Dominio.Entidades;

namespace CSBHService.Dominio.Validacao.Entidades
{
    public class TransportadoraValidacao : AbstractValidator<Transportadora>
    {
        public TransportadoraValidacao()
        {
            RuleFor(x => x.CodigoTransportadora)
                .GreaterThan(0)
                .WithMessage("Código Transportadora inválido");

            RuleFor(x => x.DescricaoTransportadora)
                .MinimumLength(3)
                .MaximumLength(80)
                .WithMessage("Descrição Transportadora inválida");

            RuleFor(x => x.Cnpj)
                .Length(14)
                .WithMessage("CNPJ inválido");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Email inválido");
        }
    }
}
