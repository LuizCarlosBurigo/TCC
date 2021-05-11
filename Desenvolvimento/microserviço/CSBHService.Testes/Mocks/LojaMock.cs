using CSBHService.Dominio.ObjetoValor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBHService.Testes.Mocks
{
    class LojaMock
    {
        private readonly MensagemConsumo _mensagem;
        private readonly CorpoEntidadeMensagem _conteudo;

        public LojaMock()
        {
            AddMensagens();
        }

        public IList mensagens { get; private set; }

        public void AddMensagens()
        {
            mensagens = new List<MensagemConsumo>();
            mensagens.Add(new MensagemConsumo(DateTime.Now, "CSBHF002", "W", (new CorpoEntidadeMensagem("003" 
                                                                                                      + "194" 
                                                                                                      + "12345678911234"
                                                                                                      + "000000010" 
                                                                                                      + "                                                                           teste"
                                                                                                      + "123456789"
                                                                                                      + "                                                                           teste"
                                                                                                      + "12345678"
                                                                                                      + "047"
                                                                                                      + "33262552"))));
        }
    }
}
