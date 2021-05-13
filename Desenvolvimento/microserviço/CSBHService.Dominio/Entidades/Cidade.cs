using MongoDB.Bson.Serialization.Attributes;

namespace CSBHService.Dominio.Entidades
{
    public class Cidade : Entidade 
    {
        public Cidade(int codigoCidade, string uf, string descricaoCidade)
        {
            CodigoCidade = codigoCidade;
            Uf = uf;
            DescricaoCidade = descricaoCidade;
        }
        [BsonElement("codigo_cidade")]
        public int CodigoCidade { get; private set; }
        [BsonElement("uf")]
        public string Uf { get; private set; }
        [BsonElement("descricao_cidade")]
        public string DescricaoCidade { get; private set; }
    }
}
