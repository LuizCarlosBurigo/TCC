using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CSBHService.Infra.Data.Repositorios
{
    public class EntradaRepositorio : IEntradaRepositorio
    {
        private readonly MongoContext<Entrada> _contexto;

        public EntradaRepositorio(IMongoDatabase database) =>
            _contexto = new MongoContext<Entrada>(database, "entrada_mercadorias");

        public async Task<Entrada> InseririOuAtualizar(Entrada entrada)
        {
            Expression<Func<Entrada, bool>> filtro = x =>
                x.CodigoEmpresa == entrada.CodigoEmpresa &&
                x.CodigoFilial == entrada.CodigoFilial &&
                x.CodigoEntrada == entrada.CodigoEntrada &&
                x.CodigoTransportadora == entrada.CodigoTransportadora;

            var updateDefenition = Builders<Entrada>.Update
                .SetOnInsert(x => x.CodigoEmpresa, entrada.CodigoEmpresa)
                .Set(x => x.CodigoFilial, entrada.CodigoFilial)
                .Set(x => x.CodigoEntrada, entrada.CodigoEntrada)
                .Set(x => x.CodigoTransportadora, entrada.CodigoTransportadora)
                .Set(x => x.DataPedido, entrada.DataPedido)
                .Set(x => x.EntradaPedido, entrada.EntradaPedido)
                .Set(x => x.Total, entrada.Total)
                .Set(x => x.Frete, entrada.Frete)
                .Set(x => x.NumeroNotaFiscal, entrada.NumeroNotaFiscal)
                .Set(x => x.SerieNotaFiscal, entrada.SerieNotaFiscal);

            await _contexto.Collection.UpdateOneAsync(filtro, updateDefenition, new UpdateOptions
            {
                IsUpsert = true

            });
            return entrada;
        }

        public async Task Excluir(Entrada entrada)
        {
            Expression<Func<Entrada, bool>> filtro = x =>
                x.CodigoEmpresa == entrada.CodigoEmpresa &&
                x.CodigoFilial == entrada.CodigoFilial &&
                x.CodigoEntrada == entrada.CodigoEntrada &&
                x.CodigoTransportadora == entrada.CodigoTransportadora;

            await _contexto.Collection.DeleteOneAsync(filtro);
        }
    }
}
