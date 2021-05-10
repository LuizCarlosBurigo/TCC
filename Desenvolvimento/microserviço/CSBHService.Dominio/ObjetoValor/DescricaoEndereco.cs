using System.Collections.Generic;
using System.Linq;

namespace CSBHService.Dominio.ObjetoValor
{
    public class DescricaoEndereco
    {
        private IList<Telefone> _telefones;
        public DescricaoEndereco(int codigoCidade, 
                                 string endereco, 
                                 int numero, 
                                 string bairro, 
                                 string cep)
        {
            CodigoCidade = codigoCidade;
            Endereco = endereco;
            Numero = numero;
            Bairro = bairro;
            Cep = cep;
            _telefones = new List<Telefone>();
        }

        public int CodigoCidade { get; private set; }
        public string Endereco { get; private set; }
        public int Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public IReadOnlyCollection<Telefone> Telefones => _telefones.ToArray();

        public void AddTelefone(Telefone novoTelefone)
        {
            foreach (var telefoneExistentes in _telefones)
            {
                if (telefoneExistentes.Ddd == novoTelefone.Ddd &&
                    telefoneExistentes.numero == novoTelefone.numero)
                {
                    return;
                }
            }
            _telefones.Add(novoTelefone);
        }
    }
}
