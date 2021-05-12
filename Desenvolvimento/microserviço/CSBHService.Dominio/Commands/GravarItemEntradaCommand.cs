using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.ObjetoValor;
using System;

namespace CSBHService.Dominio.Commands
{
    public class GravarItemEntradaCommand : ICommand
    {
        public GravarItemEntradaCommand(MensagemConsumo mensagem)
        {
            Mensagem = mensagem;
        }

        public DateTime TimeStamp { get; private set; }
        public MensagemConsumo Mensagem { get; private set; }
        public int CodigoEmpresa { get; private set; }
        public int CodigoFilial { get; private set; }
        public int CodigoEntrada { get; private set; }
        public int CodigoProduto { get; private set; }
        public int Sequencia { get; private set; }
        public int Lote { get; set; }
        public int Quantidade { get; set; }
        public double Frete { get; set; }

        public bool Validador()
        {
            try
            {
                var conteudo = this.Mensagem.Corpo.Conteudo;
                this.TimeStamp = this.Mensagem.TimeStamp;
                this.CodigoEmpresa = int.Parse(conteudo.Substring(0, 3));
                this.CodigoFilial = int.Parse(conteudo.Substring(3, 3));
                this.CodigoEntrada = int.Parse(conteudo.Substring(6, 9));
                this.CodigoProduto = int.Parse(conteudo.Substring(15, 9));
                this.Sequencia = int.Parse(conteudo.Substring(24, 09));
                this.Frete = double.Parse(conteudo.Substring(33, 13));
                this.Quantidade = int.Parse(conteudo.Substring(46, 9));
                this.Frete = double.Parse(conteudo.Substring(55, 13));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
