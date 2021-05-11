using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.ObjetoValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBHService.Dominio.Commands
{
    public class GravarSaidaCommand : ICommand
    {
        public GravarSaidaCommand(MensagemConsumo mensagem)
        {
            Mensagem = mensagem;
        }

        public DateTime TimeStamp { get; private set; }
        public MensagemConsumo Mensagem { get; private set; }
        public int CodigoEmpresa { get; private set; }
        public int CodigoFilial { get; private set; }
        public int CodigoSaida { get; private set; }
        public int CodigoTranspotadora { get; private set; }
        public double Total { get; private set; }
        public double Frete { get; private set; }
        public double Imposto { get; private set; }

        public bool Validador()
        {
            try
            {
                var conteudo = this.Mensagem.Corpo.Conteudo;
                this.TimeStamp = this.Mensagem.TimeStamp;
                this.CodigoEmpresa = int.Parse(conteudo.Substring(0, 3));
                this.CodigoFilial = int.Parse(conteudo.Substring(3, 3));
                this.CodigoSaida = int.Parse(conteudo.Substring(6, 9));
                this.CodigoTranspotadora = int.Parse(conteudo.Substring(15, 9));
                this.Total = double.Parse(conteudo.Substring(24, 13));
                this.Frete = double.Parse(conteudo.Substring(37, 13));
                this.Imposto = double.Parse(conteudo.Substring(50, 13));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
