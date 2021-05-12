using CSBHService.Dominio.ObjetoValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBHService.Dominio.Entidades
{
    public class Fornecedor : Entidade
    {
        public Fornecedor(int codigoFornecedor, 
                          string descricaoFornecedor, 
                          string cnpj, 
                          DescricaoEndereco endereco)
        {
            CodigoFornecedor = codigoFornecedor;
            DescricaoFornecedor = descricaoFornecedor;
            Cnpj = cnpj;
            Endereco = endereco;
        }

        public int CodigoFornecedor { get; private set; }
        public string DescricaoFornecedor { get; private set; }
        public string Cnpj { get; private set; }
        public string Email { get; set; }
        public DescricaoEndereco Endereco { get; private set; }
    }
}
