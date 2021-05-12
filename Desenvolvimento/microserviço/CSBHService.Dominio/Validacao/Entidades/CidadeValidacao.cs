using CSBHService.Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBHService.Dominio.Validacao.Entidades
{
    public class CidadeValidacao : AbstractValidator<Cidade>
    {
       public CidadeValidacao()
        {
            RuleFor(x => x.CodigoCidade)
                .GreaterThan(0)
                .WithMessage("Código Ciddade inválido");

            RuleFor(x => x.DescricaoCidade)
                .MinimumLength(3)
                .MaximumLength(80)
                .WithMessage("Descrição Cidade Inválida");

            RuleFor(x => x.Uf)
                .MinimumLength(2)
                .MaximumLength(10)
                .WithMessage("UF inválida");
        }
    }
}
