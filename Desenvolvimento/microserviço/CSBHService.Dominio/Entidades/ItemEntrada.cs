using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBHService.Dominio.Entidades
{
    public class ItemEntrada : EntidadeLojaBase
    {
        public ItemEntrada(int codigoEmpresa, 
                           int codigoFilial, 
                           int codigoEntrada, 
                           int codigoProduto, 
                           int sequencia) : base(codigoEmpresa, codigoFilial)
        {
            CodigoEntrada = codigoEntrada;
            CodigoProduto = codigoProduto;
            Sequencia = sequencia;
        }
        [BsonElement("codigo_entrada")]
        public int CodigoEntrada { get; private set; }
        [BsonElement("codigo_produto")]
        public int CodigoProduto { get; private set; }
        [BsonElement("sequencia")]
        public int Sequencia { get; private set; }
        [BsonElement("lote")]
        public int Lote { get; set; }
        [BsonElement("quantidade")]
        public int Quantidade { get; set; }
        [BsonElement("frete")]
        public double Frete { get; set; }
    }
}
