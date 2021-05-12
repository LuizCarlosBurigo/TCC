using CSBHService.Dominio.ObjetoValor;

namespace CSBHService.Dominio.Entidades
{
    public class Transportadora : Entidade
    {
        public Transportadora(int codigoTransportadora, string descricaoTransportadora, string cnpj,string email, DescricaoEndereco endereco)
        {
            CodigoTransportadora = codigoTransportadora;
            DescricaoTransportadora = descricaoTransportadora;
            Cnpj = cnpj;
            Email = email;
            Endereco = endereco;
        }

        public int CodigoTransportadora { get; private set; }
        public string DescricaoTransportadora { get; private set; }
        public string Cnpj { get; private set; }
        public string Email { get; private set; }
        public DescricaoEndereco Endereco { get; private set; }
    }
}
