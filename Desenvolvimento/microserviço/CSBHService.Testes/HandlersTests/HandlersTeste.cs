using CSBHService.Dominio.Commands;
using CSBHService.Dominio.Handlers;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Dominio.ObjetoValor;
using CSBHService.Infra.Data.Repositorios;
using CSBHService.Infra.InversaoDeControle;
using CSBHService.Testes.Mocks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver; 

namespace CSBHService.Testes.HandlersTests
{
    [TestClass]
    public class HandlersTeste
    {
        private readonly CidadeMock _cidadeMock;
        private readonly LojaMock _lojaMock;
        private readonly SaidaMock _saidaMock;
        private readonly ItemSaidaMock _itemSaidaMock;
        private readonly TransportadoraMock _transportadoraMock;
        private readonly FornecedorMock _fornecedorMock;
        private readonly EntradaMock _entradaMock;
        private readonly ItemEntradaMock _itemEntradaMock;
        private readonly ProdutoMock _produtoMock;
        private readonly IMongoDatabase _database;
        private readonly ICidadeRepositorio _cidadeRepositorio;
        private readonly IEntradaRepositorio _entradaRepositorio;
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        private readonly IItemEntradaRepositorio _itemEntradaRepositorio;
        private readonly IItemSaidaRepositorio _itemSaidaRepositorio;
        private readonly ILojaRepositorio _lojaRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly ITransportadoraRepositorio _transportadoraRepositorio;
        private readonly ISaidaRepositorio _saidaRepositorio;
  

        public HandlersTeste()
        {
            _cidadeMock = new CidadeMock();
            _lojaMock = new LojaMock();
            _saidaMock = new SaidaMock();
            _itemSaidaMock = new ItemSaidaMock();
            _transportadoraMock = new TransportadoraMock();
            _fornecedorMock = new FornecedorMock();
            _entradaMock = new EntradaMock();
            _itemEntradaMock = new ItemEntradaMock();
            _produtoMock = new ProdutoMock();
            var connerctionString = "mongodb://localhost:27017";
            var database = "LojaTesteHandler";
            var cliente = new MongoClient(connerctionString);
            _database = cliente.GetDatabase(database);
            _cidadeRepositorio = new CidadeRepositorio(_database);
            _entradaRepositorio = new EntradaRepositorio(_database);
            _fornecedorRepositorio = new FornecedorRepositorio(_database);
            _itemEntradaRepositorio = new ItemEntradaRepositorio(_database);
            _itemSaidaRepositorio = new ItemSaidaRepositorio(_database);
            _lojaRepositorio = new LojaRepositorio(_database);
            _produtoRepositorio = new ProdutoRepositorio(_database);
            _transportadoraRepositorio = new TransportadoraRepositorio(_database);
            _saidaRepositorio = new SaidaRepositorio(_database);
        }

        //Executar CidadeHandler
        [TestMethod]
        public void Testar_CidadeHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_cidadeMock.mensagens[0];
            var comando = new GravarCidadeCommand(mensagem);
            var handler = new CidadeHandler(_cidadeRepositorio);
            var resultado =(CommandResult) handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }

        //Executar EntradaHandler
        [TestMethod]
        public void Testar_EntradaHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_entradaMock.mensagens[0];
            var comando = new GravarEntradaCommand(mensagem);
            var handler = new EntradaHandler(_entradaRepositorio);
            var resultado = (CommandResult)handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }

        //Executar FornecedorHandler
        [TestMethod]
        public void Testar_FornecedorHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_fornecedorMock.mensagens[0];
            var comando = new GravarFornecedorCommand(mensagem);
            var handler = new FornecedorHandler(_fornecedorRepositorio);
            var resultado = (CommandResult)handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }

        //Executar ItemEntradaHandler
        [TestMethod]
        public void Testar_ItemEntradaHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_itemEntradaMock.mensagens[0];
            var comando = new GravarItemEntradaCommand(mensagem);
            var handler = new ItemEntradaHandler(_itemEntradaRepositorio);
            var resultado = (CommandResult)handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }

        //Executar ItemSaidaHandler
        [TestMethod]
        public void Testar_ItemSaidaHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_itemSaidaMock.mensagens[0];
            var comando = new GravarItemSaidaCommand(mensagem);
            var handler = new ItemSaidaHandler(_itemSaidaRepositorio);
            var resultado = (CommandResult)handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }

        //Executar LojaHandler
        [TestMethod]
        public void Testar_LojaHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_lojaMock.mensagens[0];
            var comando = new GravarLojaCommand(mensagem);
            var handler = new LojaHandler(_lojaRepositorio);
            var resultado = (CommandResult)handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }

        //Executar ProdutoHandler
        [TestMethod]
        public void Testar_ProdutoHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_produtoMock.mensagens[0];
            var comando = new GravarProdutoCommand(mensagem);
            var handler = new ProdutoHandler(_produtoRepositorio);
            var resultado = (CommandResult)handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }

        //Executar TransportadoraHandler
        [TestMethod]
        public void Testar_TransportadoraHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_transportadoraMock.mensagens[0];
            var comando = new GravarTransportadoraCommand(mensagem);
            var handler = new TransportadoraHandler(_transportadoraRepositorio);
            var resultado = (CommandResult)handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }

        //Executar SaidaHandler
        [TestMethod]
        public void Testar_SaidaHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_saidaMock.mensagens[0];
            var comando = new GravarSaidaCommand(mensagem);
            var handler = new SaidaHandler(_saidaRepositorio);
            var resultado = (CommandResult)handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }
    }
}
