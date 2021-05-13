using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.ObjetoValor;
using System;

namespace CSBHService.Dominio.Commands
{
    public class GravarLojaCommand : ICommand
    {
        public GravarLojaCommand(MensagemConsumo mensagem)
        {
            Mensagem = mensagem;
        }
        public DateTime TimeStamp { get; private set; }
        public MensagemConsumo Mensagem { get; private set; }
        public int CodigoEmpresa { get; private set; }
        public int CodigoFilial { get; private set; }
        public string Cnpj { get; private set; }
        public DescricaoEndereco Endereco { get; private set; }
        public bool Validador()
        {
            try
            {
                var conteudo = this.Mensagem.Corpo.Conteudo;
                var campoFinal = conteudo.Length - 209;
                this.TimeStamp = this.Mensagem.TimeStamp;
                this.CodigoEmpresa = int.Parse(conteudo.Substring(0, 3));
                this.CodigoFilial = int.Parse(conteudo.Substring(3, 3));
                this.Cnpj = conteudo.Substring(6, 14);
                var cdCidade = int.Parse(conteudo.Substring(20, 9));
                var endereco = conteudo.Substring(29, 80);
                endereco = endereco.TrimStart().TrimEnd();
                var numero = int.Parse(conteudo.Substring(109, 9));
                var bairro = conteudo.Substring(118, 80).TrimStart().TrimEnd();
                bairro = bairro.TrimStart().TrimEnd();
                var cep = conteudo.Substring(198, 8);
                
                this.Endereco = new DescricaoEndereco(cdCidade,
                                                      endereco,
                                                      numero,
                                                      bairro,
                                                      cep);
                
                var ddd = int.Parse(conteudo.Substring(206, 3));
                var telefone = int.Parse(conteudo.Substring(209, campoFinal));
               
                Telefone novoTelefone = new Telefone(ddd, telefone);
                Endereco.AddTelefone(novoTelefone);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
