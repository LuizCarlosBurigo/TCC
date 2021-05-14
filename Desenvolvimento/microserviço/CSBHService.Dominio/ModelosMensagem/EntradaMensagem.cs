using CSBHService.Dominio.ObjetoValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBHService.Dominio.ModelosMensagem
{
    public class EntradaMensagem : MensagemModeloBase
    {
        public EntradaMensagem(DateTime timeStamp, 
                               string arquivo, 
                               string acao, 
                               CorpoEntidadeMensagem entrada) : base(timeStamp, arquivo, acao)
        {
            Entrada = entrada;
        }

        public CorpoEntidadeMensagem Entrada { get; set; }
    }
}
