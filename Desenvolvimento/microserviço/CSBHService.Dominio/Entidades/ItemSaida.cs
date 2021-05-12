
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

        public int CodigoSaida { get; private set; }
        public int CodigoProduto { get; private set; }
        public int Sequencia { get; private set; }
        public int CodigoLote { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
    }
}
