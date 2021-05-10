using FluentValidation;
using CSBHService.Dominio.Entidades;

namespace CSBHService.Dominio.Validacao.Entidades
{
    public class LojaValidacao : EntidadeLojaBaseValidacao<Loja>
    {
        public LojaValidacao()
        {
            RuleFor(x => x.Cnpj)
                .Length(14)
                .WithMessage("CNPJ inválido");

        }
    }
}
