using System;
using System.Collections.Generic;

namespace CSBHService.Dominio.ObjetoValor
{
    public class MensagemConsumo
    {
        public MensagemConsumo(DateTime timeStamp, string arquivo, string acao, CorpoEntidadeMensagem corpo)
        {
            TimeStamp = timeStamp;
            Arquivo = arquivo;
            Acao = acao;
            Corpo = corpo;
        }

        public DateTime TimeStamp { get; set; }
        public string Arquivo { get; set; }
        public string Acao { get; set; }
        public CorpoEntidadeMensagem Corpo { get; set; }

    }
}
