using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.ObjetoValor;
using System;

namespace CSBHService.Dominio.Commands
{
    public class GravarEntradaCommand : ICommand
    {
        public GravarEntradaCommand(MensagemConsumo mensagem)
        {
            Mensagem = mensagem;
        }

        public DateTime TimeStamp { get; private set; }
        public MensagemConsumo Mensagem { get; private set; }
        public int CodigoEmpresa { get; private set; }
        public int CodigoFilial { get; private set; }
        public int CodigoEntrada { get; private set; }
        public int CodigoTransportadora { get; private set; }
        public DateTime DataPedido { get; set; }
        public DateTime EntradaPedido { get; set; }
        public double Total { get; set; }
        public double Frete { get; set; }
        public int NumeroNotaFiscal { get; set; }
        public int SerieNotaFiscal { get; set; }

        public bool Validador()
        {
            try
            {
                var conteudo = this.Mensagem.Corpo.Conteudo;
                this.TimeStamp = this.Mensagem.TimeStamp;
                this.CodigoEmpresa = int.Parse(conteudo.Substring(0, 3));
                this.CodigoFilial = int.Parse(conteudo.Substring(3, 3));
                this.CodigoEntrada = int.Parse(conteudo.Substring(6, 9));
                this.CodigoTransportadora = int.Parse(conteudo.Substring(15, 9));
                var dataPedido = conteudo.Substring(24, 4) + "/" + conteudo.Substring(28, 2) + "/" + conteudo.Substring(30, 2);
                this.DataPedido = Convert.ToDateTime(dataPedido);
                var entradaPedido = conteudo.Substring(32, 4) + "/" + conteudo.Substring(36, 2) + "/" + conteudo.Substring(38, 2);
                this.EntradaPedido = Convert.ToDateTime(entradaPedido);
                this.Total = double.Parse(conteudo.Substring(40, 13));
                this.Frete = double.Parse(conteudo.Substring(53, 13));
                this.NumeroNotaFiscal = int.Parse(conteudo.Substring(66, 9));
                this.SerieNotaFiscal = int.Parse(conteudo.Substring(75, 3));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
