using MongoDB.Bson.Serialization.Attributes;

namespace CSBHService.Dominio.Entidades
{
    public abstract class EntidadeLojaBase : Entidade
    {
        protected EntidadeLojaBase(int codigoEmpresa, int codigoFilial)
        {
            CodigoEmpresa = codigoEmpresa;
            CodigoFilial = codigoFilial;
        }
        [BsonElement("codigo_empresa")]
        public int CodigoEmpresa { get; private set; }
        [BsonElement("codigo_filial")]
        public int CodigoFilial { get; private set; }
    }
}
