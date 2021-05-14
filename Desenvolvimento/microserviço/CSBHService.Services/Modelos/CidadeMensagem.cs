
using CSBHService.Dominio.Interfaces.Consumidor;
using CSBHService.Dominio.ObjetoValor;
using System;

namespace CSBHService.Servicos.Modelos
{
    public class CidadeMensagem : IMensagemConsumidor
    {
        public CidadeMensagem(DateTime timeStamp, string arquivo, string acao, CorpoEntidadeMensagem cidade)
        {
            TimeStamp = timeStamp;
            Arquivo = arquivo;
            Acao = acao;
            this.cidade = cidade;
        }

        public DateTime TimeStamp { get; set; }
        public string Arquivo { get; set; }
        public string Acao { get; set; }
        public CorpoEntidadeMensagem cidade { get; set; }
    }
}
