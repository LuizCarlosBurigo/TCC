using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBHService.Dominio.ModelosMensagem
{
    public abstract class MensagemModeloBase
    {
        protected MensagemModeloBase(DateTime timeStamp, string arquivo, string acao)
        {
            TimeStamp = timeStamp;
            Arquivo = arquivo;
            Acao = acao;
        }

        public DateTime TimeStamp { get; set; }
        public string Arquivo { get; set; }
        public string Acao { get; set; }

    }
}
