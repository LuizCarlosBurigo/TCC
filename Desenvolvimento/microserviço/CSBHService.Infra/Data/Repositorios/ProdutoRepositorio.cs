using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CSBHService.Infra.Data.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {

        private readonly MongoContext<Produto> _contexto;

        public ProdutoRepositorio(IMongoDatabase database) =>
            _contexto = new MongoContext<Produto>(database, "mercadoria");

        public async Task<Produto> InseririOuAtualizar(Produto produto)
        {
            Expression<Func<Produto, bool>> filtro = x =>
                x.CodigoEmpresa == produto.CodigoEmpresa &&
                x.CodigoFilial == produto.CodigoFilial &&
                x.CodigoEntrada == produto.CodigoEntrada &&
                x.CodigoProduto == produto.CodigoProduto &&
                x.Sequencia == produto.Sequencia;

            Produto novaProduto = _contexto.Collection.Find(filtro).FirstOrDefault();

            if (novaProduto != null)
            {
                await _contexto.Collection.ReplaceOneAsync(filtro, produto);
                return produto;
            }
            await _contexto.Collection.InsertOneAsync(produto);
            return produto;
        }

        public async Task Excluir(Produto produto)
        {
            Expression<Func<Produto, bool>> filtro = x =>
                x.CodigoEmpresa == produto.CodigoEmpresa &&
                x.CodigoFilial == produto.CodigoFilial &&
                x.CodigoEntrada == produto.CodigoEntrada &&
                x.CodigoProduto == produto.CodigoProduto &&
                x.Sequencia == produto.Sequencia;

            await _contexto.Collection.DeleteOneAsync(filtro);
        }
    }
}
