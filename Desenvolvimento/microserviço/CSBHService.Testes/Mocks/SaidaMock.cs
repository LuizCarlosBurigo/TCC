using CSBHService.Dominio.ObjetoValor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBHService.Testes.Mocks
{
    public class SaidaMock
    {
        private readonly MensagemConsumo _mensagem;
        private readonly CorpoEntidadeMensagem _conteudo;

        public SaidaMock()
        {
            AddMensagens();
        }

        public IList mensagens { get; private set; }

        public void AddMensagens()
        {
            mensagens = new List<MensagemConsumo>();
            mensagens.Add(new MensagemConsumo(DateTime.Now, "CSBHF002", "W", (new CorpoEntidadeMensagem("003"
                                                                                                      + "194"
                                                                                                      + "123456789"
                                                                                                      + "123456789"
                                                                                                      + "0000000012,10"
                                                                                                      + "0000000022,10"
                                                                                                      + "0000000032,10"))));
        }
    }
}
