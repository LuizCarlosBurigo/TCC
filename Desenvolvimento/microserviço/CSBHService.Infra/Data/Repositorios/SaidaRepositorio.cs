using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CSBHService.Infra.Data.Repositorios
{
    public class SaidaRepositorio : ISaidaRepositorio
    {

        private readonly MongoContext<Saida> _contexto;

        public SaidaRepositorio(IMongoDatabase database) =>
            _contexto = new MongoContext<Saida>(database, "saida_mercadoria");

        public async Task<Saida> InseririOuAtualizar(Saida saida)
        {
            Expression<Func<Saida, bool>> filtro = x =>
                x.CodigoEmpresa == saida.CodigoEmpresa &&
                x.CodigoFilial == saida.CodigoFilial &&
                x.CodigoSaida == saida.CodigoSaida;

            var updateDefenition = Builders<Saida>.Update
                .SetOnInsert(x => x.CodigoEmpresa, saida.CodigoEmpresa)
                .Set(x => x.CodigoFilial, saida.CodigoFilial)
                .Set(x => x.CodigoSaida, saida.CodigoSaida)
                .Set(x => x.CodigoTranspotadora, saida.CodigoTranspotadora)
                .Set(x => x.Total, saida.Total)
                .Set(x => x.Frete, saida.Frete)
                .Set(x => x.Imposto, saida.Imposto);

            await _contexto.Collection.UpdateOneAsync(filtro, updateDefenition, new UpdateOptions
            {
                IsUpsert = true

            });
            return saida;
        }

        public async Task Excluir(Saida saida)
        {
            Expression<Func<Saida, bool>> filtro = x =>
                x.CodigoEmpresa == saida.CodigoEmpresa &&
                x.CodigoFilial == saida.CodigoFilial &&
                x.CodigoSaida == saida.CodigoSaida;

            await _contexto.Collection.DeleteOneAsync(filtro);
        }
    }
}
