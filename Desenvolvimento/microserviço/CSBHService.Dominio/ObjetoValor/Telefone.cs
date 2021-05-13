using MongoDB.Bson.Serialization.Attributes;

namespace CSBHService.Dominio.ObjetoValor
{
    public class Telefone
    {
        public Telefone(int ddd, int numero)
        {
            Ddd = ddd;
            this.numero = numero;
        }
        [BsonElement("ddd")]
        public int Ddd { get; set; }
        [BsonElement("numero_telefone")]
        public int numero { get; set; }
    }
}
