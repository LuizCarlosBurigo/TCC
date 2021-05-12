
using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.ObjetoValor;
using System;

namespace CSBHService.Dominio.Commands
{
    public class GravarFornecedorCommand : ICommand
    {
        public GravarFornecedorCommand(MensagemConsumo mensagem)
        {
            Mensagem = mensagem;
        }
        public DateTime TimeStamp { get; private set; }
        public MensagemConsumo Mensagem { get; private set; }
        public int CodigoFornecedor { get; private set; }
        public string DescricaoFornecedor { get; private set; }
        public string Cnpj { get; private set; }
        public string Email { get; private set; }
        public DescricaoEndereco Endereco { get; private set; }


        public bool Validador()
        {
            try
            {
                var conteudo = this.Mensagem.Corpo.Conteudo;
                var campoFinal = conteudo.Length - 301;
                this.TimeStamp = this.Mensagem.TimeStamp;
                this.CodigoFornecedor = int.Parse(conteudo.Substring(0, 9));
                var cdCidade = int.Parse(conteudo.Substring(9, 9));
                this.DescricaoFornecedor = conteudo.Substring(18, 80);
                this.Cnpj = conteudo.Substring(98, 14);
                var endereco = conteudo.Substring(112, 80);
                var numero = int.Parse(conteudo.Substring(192, 9));
                var bairro = conteudo.Substring(201, 80);
                var cep = conteudo.Substring(281, 08);
                var email = conteudo.Substring(301, campoFinal);
                this.Endereco = new DescricaoEndereco(cdCidade,
                                                      endereco,
                                                      numero,
                                                      bairro,
                                                      cep);

                var ddd = int.Parse(conteudo.Substring(289, 3));
                var telefone = int.Parse(conteudo.Substring(292, 8));

                Telefone novoTelefone = new Telefone(ddd, telefone);
                Endereco.AddTelefone(novoTelefone);
                this.Email = email;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
