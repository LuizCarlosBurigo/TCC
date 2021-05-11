using CSBHService.Dominio.ObjetoValor;

namespace CSBHService.Dominio.Entidades
{
    public class Loja : EntidadeLojaBase
    {
        public Loja(int codigoEmpresa, 
                    int codigoFilial, string cnpj, DescricaoEndereco endereco) : base(codigoEmpresa, codigoFilial)
        {
            Cnpj = cnpj;
            Endereco = endereco;
        }

        public string Cnpj { get; private set; }
        public DescricaoEndereco Endereco { get; private set; }
    }
}
