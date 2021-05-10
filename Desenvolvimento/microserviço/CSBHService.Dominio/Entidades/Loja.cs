using CSBHService.Dominio.ObjetoValor;

namespace CSBHService.Dominio.Entidades
{
    public class Loja : EntidadeLojaBase
    {
        public Loja(int codigoEmpresa, 
                    int codigoFilial) : base(codigoEmpresa, codigoFilial)
        {

        }

        public string Cnpj { get; private set; }
        public DescricaoEndereco Endereco { get; set; }
    }
}
