using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CSBHService.Infra.Data.Repositorios
{
    public class TransportadoraRepositorio : ITransportadoraRepositorio
    {

        private readonly MongoContext<Transportadora> _contexto;

        public TransportadoraRepositorio(IMongoDatabase database) =>
            _contexto = new MongoContext<Transportadora>(database, "transportadora");

        public async Task<Transportadora> InseririOuAtualizar(Transportadora transportadora)
        {
            Expression<Func<Transportadora, bool>> filtro = x =>
                x.CodigoTransportadora == transportadora.CodigoTransportadora &&
                x.Endereco.CodigoCidade == transportadora.Endereco.CodigoCidade;

            var updateDefenition = Builders<Transportadora>.Update
                .SetOnInsert(x => x.CodigoTransportadora, transportadora.CodigoTransportadora)
                .Set(x => x.DescricaoTransportadora, transportadora.DescricaoTransportadora)
                .Set(x => x.Cnpj, transportadora.Cnpj)
                .Set(x => x.Email, transportadora.Email)
                .Set(x => x.Endereco, transportadora.Endereco);

            await _contexto.Collection.UpdateOneAsync(filtro, updateDefenition, new UpdateOptions
            {
                IsUpsert = true

            });
            return transportadora;
        }
        public async Task Excluir(Transportadora transportadora)
        {
            Expression<Func<Transportadora, bool>> filtro = x =>
                x.CodigoTransportadora == transportadora.CodigoTransportadora &&
                x.Endereco.CodigoCidade == transportadora.Endereco.CodigoCidade;

            await _contexto.Collection.DeleteOneAsync(filtro);
        }

    }
}
