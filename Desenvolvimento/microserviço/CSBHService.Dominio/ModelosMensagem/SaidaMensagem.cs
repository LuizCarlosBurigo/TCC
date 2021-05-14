using CSBHService.Dominio.ObjetoValor;
using System;

namespace CSBHService.Dominio.ModelosMensagem
{
    public class SaidaMensagem : MensagemModeloBase
    {
        public SaidaMensagem(DateTime timeStamp, 
                            string arquivo, 
                            string acao, 
                            CorpoEntidadeMensagem saida) : base(timeStamp, arquivo, acao)
        {
            Saida = saida;
        }

        public CorpoEntidadeMensagem Saida { get; set; }
    }
}
