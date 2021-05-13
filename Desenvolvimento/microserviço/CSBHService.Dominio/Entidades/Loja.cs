using CSBHService.Dominio.ObjetoValor;
using MongoDB.Bson.Serialization.Attributes;

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
        [BsonElement("cnpj")]
        public string Cnpj { get; private set; }
        public DescricaoEndereco Endereco { get; private set; }
    }
}
