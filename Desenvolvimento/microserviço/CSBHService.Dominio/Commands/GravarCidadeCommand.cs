using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.ObjetoValor;
using System;

namespace CSBHService.Dominio.Commands
{
    public class GravarCidadeCommand : ICommand
    {
        public GravarCidadeCommand(MensagemConsumo mensagem)
        {
            Mensagem = mensagem;
        }

        public int CodigoCidade { get; private set; }
        public string Uf { get; private set; }
        public string DescricaoCidade { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public MensagemConsumo Mensagem { get; private set; }

        public bool Validador()
        {
            try
            {
                var conteudo = this.Mensagem.Corpo.Conteudo;
                var campoFinal = conteudo.Length - 18;
                this.TimeStamp = this.Mensagem.TimeStamp;
                this.CodigoCidade = int.Parse(conteudo.Substring(0, 9));
                this.Uf = conteudo.Substring(9, 9);
                this.Uf = this.Uf.TrimStart().TrimEnd();
                this.DescricaoCidade = conteudo.Substring(18, campoFinal);
                this.DescricaoCidade = this.DescricaoCidade.TrimStart().TrimEnd();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
