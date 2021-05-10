using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBHService.Dominio.Entidades
{
    public class Cidade 
    {
        public Cidade(int codigoCidade, string uf, string descricaoCidade)
        {
            CodigoCidade = codigoCidade;
            Uf = uf;
            DescricaoCidade = descricaoCidade;
        }

        public int CodigoCidade { get; private set; }
        public string Uf { get; private set; }
        public string DescricaoCidade { get; private set; }
    }
}
