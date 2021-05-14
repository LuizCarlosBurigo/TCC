using CSBHService.Dominio.ObjetoValor;
using System;

namespace CSBHService.Dominio.ModelosMensagem
{
    public class LojaMensagem : MensagemModeloBase
    {
        public LojaMensagem(DateTime timeStamp, 
                            string arquivo, 
                            string acao, 
                            CorpoEntidadeMensagem loja) : base(timeStamp, arquivo, acao)
        {
            Loja = loja;
        }

        public CorpoEntidadeMensagem Loja { get; set; }
    }
}
