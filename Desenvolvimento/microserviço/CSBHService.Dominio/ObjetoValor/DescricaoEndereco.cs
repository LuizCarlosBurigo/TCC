using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBHService.Dominio.ObjetoValor
{
    public class DescricaoEndereco
    {
        public DescricaoEndereco(int codigoCidade, 
                                 string endereco, 
                                 int numero, 
                                 string bairro, 
                                 string cep,
                                 int telefone)
        {
            CodigoCidade = codigoCidade;
            Endereco = endereco;
            Numero = numero;
            Bairro = bairro;
            Cep = cep;
            Telefone = telefone;
        }

        public int CodigoCidade { get; private set; }
        public string Endereco { get; private set; }
        public int Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public int Telefone { get; private set; }
    }
}
