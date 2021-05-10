using CSBHService.Dominio.Entidades;
using FluentValidation;

namespace CSBHService.Dominio.Validacao.Entidades
{
    public class EntradaValidacao : EntidadeLojaBaseValidacao<Entrada>
    {
        public EntradaValidacao()
        {
            RuleFor(x => x.CodigoEntrada)
                .GreaterThan(0)
                .WithMessage("Código Entrada inválido");

            RuleFor(x => x.CodigoTransportadora)
                .GreaterThan(0)
                .WithMessage("Código Transportadora inválido");
        }
    }
}
