using CSBHService.Dominio.Entidades;
using FluentValidation;

namespace CSBHService.Dominio.Validacao.Entidades
{
    public class SaidaValidacao : EntidadeLojaBaseValidacao<Saida>
    {
        public SaidaValidacao()
        {
            RuleFor(x => x.CodigoSaida)
                .GreaterThan(0)
                .WithMessage("Código Saida inválido");

            RuleFor(x => x.CodigoTranspotadora)
                .GreaterThan(0)
                .WithMessage("Código Transportadora inválido");
        }
    }
}
