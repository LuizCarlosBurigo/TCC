using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;


namespace CSBHService.Infra.Data.Repositorios
{
    public class CidadeRepositorio : ICidadeRepositorio
    {
        private readonly MongoContext<Cidade> _contexto;

        public CidadeRepositorio(IMongoDatabase database) =>
            _contexto = new MongoContext<Cidade>(database, "cidade");

        public async Task<Cidade> InseririOuAtualizar(Cidade cidade)
        {
            Expression<Func<Cidade, bool>> filtro = x =>
                x.CodigoCidade == cidade.CodigoCidade &&
                x.Uf == cidade.Uf &&
                x.DescricaoCidade == cidade.DescricaoCidade;

            var updateDefenition = Builders<Cidade>.Update
                .SetOnInsert(x => x.CodigoCidade, cidade.CodigoCidade)
                .Set(x => x.Uf, cidade.Uf)
                .Set(x => x.DescricaoCidade, cidade.DescricaoCidade);

            await _contexto.Collection.UpdateOneAsync(filtro, updateDefenition, new UpdateOptions
            {
                IsUpsert = true

            });
            return cidade;
        }

        public async Task Excluir(Cidade cidade)
        {
            Expression<Func<Cidade, bool>> filtro = x =>
                x.CodigoCidade == cidade.CodigoCidade &&
                x.Uf == cidade.Uf &&
                x.DescricaoCidade == cidade.DescricaoCidade;

            await _contexto.Collection.DeleteOneAsync(filtro);

        }
    }
}
