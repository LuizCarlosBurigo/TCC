using CSBHService.Dominio.Entidades;
using FluentValidation;

namespace CSBHService.Dominio.Validacao.Entidades
{
    public class ItemSaidaValidacao : EntidadeLojaBaseValidacao<ItemSaida>
    {
        public ItemSaidaValidacao()
        {
            RuleFor(x => x.CodigoSaida)
                .GreaterThan(0)
                .WithMessage("Código Saida inválido");

            RuleFor(x => x.CodigoProduto)
                .GreaterThan(0)
                .WithMessage("Códido Produto inválido");

            RuleFor(x => x.Sequencia)
                .GreaterThan(0)
                .WithMessage("Número Sequencia inválido");
        }
    }
}
