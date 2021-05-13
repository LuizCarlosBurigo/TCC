using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CSBHService.Infra.Data.Repositorios
{
    public class ItemEntradaRepositorio : IItemEntradaRepositorio
    {
        private readonly MongoContext<ItemEntrada> _contexto;

        public ItemEntradaRepositorio(IMongoDatabase database) =>
            _contexto = new MongoContext<ItemEntrada>(database, "item_entrada_deposito");

        public async Task<ItemEntrada> InseririOuAtualizar(ItemEntrada item)
        {
            Expression<Func<ItemEntrada, bool>> filtro = x =>
                x.CodigoEmpresa == item.CodigoEmpresa &&
                x.CodigoFilial == item.CodigoFilial &&
                x.CodigoEntrada == item.CodigoEntrada &&
                x.CodigoProduto == item.CodigoProduto &&
                x.Sequencia == item.Sequencia;

            ItemEntrada novaItem = _contexto.Collection.Find(filtro).FirstOrDefault();

            if (novaItem != null)
            {
                await _contexto.Collection.FindOneAndReplaceAsync(filtro, item);
                return item;
            }
            await _contexto.Collection.InsertOneAsync(item);
            return item;
        }

        public async Task Excluir(ItemEntrada item)
        {
            Expression<Func<ItemEntrada, bool>> filtro = x =>
                x.CodigoEmpresa == item.CodigoEmpresa &&
                x.CodigoFilial == item.CodigoFilial &&
                x.CodigoEntrada == item.CodigoEntrada &&
                x.CodigoProduto == item.CodigoProduto &&
                x.Sequencia == item.Sequencia;

            await _contexto.Collection.DeleteOneAsync(filtro);
        }
    }
}
