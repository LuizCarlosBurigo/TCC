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

            Cidade novaCidade = _contexto.Collection.Find(filtro).FirstOrDefault();

            if (novaCidade != null)
            {
                await _contexto.Collection.ReplaceOneAsync(filtro, cidade);
                return cidade;
            }
            await _contexto.Collection.InsertOneAsync(cidade);
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
