using CSBHService.Dominio.ObjetoValor;
using MongoDB.Bson.Serialization.Attributes;

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
        [BsonElement("codigo_transportadora")]
        public int CodigoTransportadora { get; private set; }
        [BsonElement("descricao_transportadora")]
        public string DescricaoTransportadora { get; private set; }
        [BsonElement("cnpj")]
        public string Cnpj { get; private set; }
        [BsonElement("email")]
        public string Email { get; private set; }
        public DescricaoEndereco Endereco { get; private set; }
    }
}
