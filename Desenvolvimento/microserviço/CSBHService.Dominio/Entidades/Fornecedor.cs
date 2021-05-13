using CSBHService.Dominio.ObjetoValor;
using MongoDB.Bson.Serialization.Attributes;

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
        [BsonElement("codigo_fornecedor")]
        public int CodigoFornecedor { get; private set; }
        [BsonElement("descricao_fornecedor")]
        public string DescricaoFornecedor { get; private set; }
        [BsonElement("cnpj")]
        public string Cnpj { get; private set; }
        [BsonElement("email")]
        public string Email { get; set; }
        public DescricaoEndereco Endereco { get; private set; }
    }
}
