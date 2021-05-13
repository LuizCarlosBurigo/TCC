
using MongoDB.Bson.Serialization.Attributes;

namespace CSBHService.Dominio.Entidades
{
    public class ItemSaida : EntidadeLojaBase
    {
        public ItemSaida(int codigoEmpresa, 
                         int codigoFilial,  
                         int codigoSaida, 
                         int codigoProduto,
                         int sequencia) : base(codigoEmpresa, codigoFilial)
        {
            CodigoSaida = codigoSaida;
            CodigoProduto = codigoProduto;
            Sequencia = sequencia;
        }
        [BsonElement("codigo_saida")]
        public int CodigoSaida { get; private set; }
        [BsonElement("codigo_produto")]
        public int CodigoProduto { get; private set; }
        [BsonElement("sequencia")]
        public int Sequencia { get; private set; }
        [BsonElement("lote")]
        public int CodigoLote { get; set; }
        [BsonElement("quantidade")]
        public int Quantidade { get; set; }
        [BsonElement("valor")]
        public double Valor { get; set; }
    }
}
