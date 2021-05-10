using CSBHService.Dominio.Entidades;
using FluentValidation;

namespace CSBHService.Dominio.Validacao.Entidades
{
    public abstract class EntidadeLojaBaseValidacao<TEntitdade> : AbstractValidator<TEntitdade>
        where TEntitdade : EntidadeLojaBase
    {
        protected EntidadeLojaBaseValidacao()
        {
            RuleFor(x => x.CodigoEmpresa)
                .NotNull()
                .NotEmpty()
                .WithMessage("Código Empresa inválido");

            RuleFor(x => x.CodigoFilial)
                .NotNull()
                .NotEmpty()
                .WithMessage("Código Filial inválido");
        }
    }
}
