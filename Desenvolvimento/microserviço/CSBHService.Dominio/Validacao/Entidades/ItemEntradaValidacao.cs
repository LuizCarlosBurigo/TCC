using CSBHService.Dominio.Entidades;
using FluentValidation;

namespace CSBHService.Dominio.Validacao.Entidades
{
    public class ItemEntradaValidacao : EntidadeLojaBaseValidacao<ItemEntrada>
    {
        public ItemEntradaValidacao()
        {
            RuleFor(x => x.CodigoEntrada)
                .GreaterThan(0)
                .WithMessage("Código Entrada inválido");

            RuleFor(x => x.CodigoProduto)
                .GreaterThan(0)
                .WithMessage("Códido Produto inválido");

            RuleFor(x => x.Sequencia)
                .GreaterThan(0)
                .WithMessage("Número Sequencia inválido");
        }
    }
}
