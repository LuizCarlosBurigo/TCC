using FluentValidation;
using CSBHService.Dominio.Entidades;

namespace CSBHService.Dominio.Validacao.Entidades
{
    public class ProdutoValidacao : EntidadeLojaBaseValidacao<Produto>
    {
        public ProdutoValidacao()
        {
            RuleFor(x => x.CodigoEntrada)
                .GreaterThan(0)
                .WithMessage("Código Produto inválido");

            RuleFor(x => x.CodigoProduto)
                .GreaterThan(0)
                .WithMessage("Códido Produto inválido");

            RuleFor(x => x.Sequencia)
                .GreaterThan(0)
                .WithMessage("Número Sequencia inválido");
        }
    }
}
