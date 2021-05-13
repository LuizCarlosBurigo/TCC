using MongoDB.Bson.Serialization.Attributes;

namespace CSBHService.Dominio.Entidades
{
    public class Saida : EntidadeLojaBase
    {
        public Saida(int codigoEmpresa, 
                     int codigoFilial,
                     int codigoSaida, 
                     int codigoTranspotadora) : base(codigoEmpresa, codigoFilial)
        {
            CodigoSaida = codigoSaida;
            CodigoTranspotadora = codigoTranspotadora;
        }
        [BsonElement("codigo_saida")]
        public int CodigoSaida { get; private set; }
        [BsonElement("codigo_transportadora")]
        public int CodigoTranspotadora { get; private set; }
        [BsonElement("total")]
        public double Total { get; set; }
        [BsonElement("frete")]
        public double Frete { get; set; }
        [BsonElement("imposto")]
        public double Imposto { get; set; }
    }
}
