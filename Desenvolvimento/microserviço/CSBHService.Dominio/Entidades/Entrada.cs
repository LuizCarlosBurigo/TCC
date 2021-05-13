using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBHService.Dominio.Entidades
{
    public class Entrada : EntidadeLojaBase
    {
        public Entrada(int codigoEmpresa, 
                       int codigoFilial, 
                       int codigoEntrada, 
                       int codigoTransportadora) : base(codigoEmpresa, codigoFilial)
        {
            CodigoEntrada = codigoEntrada;
            CodigoTransportadora = codigoTransportadora;
        }
        [BsonElement("codigo_entrada")]
        public int CodigoEntrada { get; private set; }
        [BsonElement("codigo_transportadora")]
        public int CodigoTransportadora { get; private set; }
        [BsonElement("data_pedido")]
        public DateTime DataPedido { get; set; }
        [BsonElement("data_entrada_pedido")]
        public DateTime EntradaPedido { get; set; }
        [BsonElement("total")]
        public double Total { get; set; }
        [BsonElement("frete")]
        public double Frete { get; set; }
        [BsonElement("nota_fiscal")]
        public int NumeroNotaFiscal { get; set; }
        [BsonElement("serie_nota_fiscal")]
        public int SerieNotaFiscal { get; set; }

    }
}
