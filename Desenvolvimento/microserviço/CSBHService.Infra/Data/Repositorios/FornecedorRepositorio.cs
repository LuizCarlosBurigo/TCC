using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CSBHService.Infra.Data.Repositorios
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {

        private readonly MongoContext<Fornecedor> _contexto;

        public FornecedorRepositorio(IMongoDatabase database) =>
            _contexto = new MongoContext<Fornecedor>(database, "fornecedor");

        public async Task<Fornecedor> InseririOuAtualizar(Fornecedor fornecedor)
        {
            Expression<Func<Fornecedor, bool>> filtro = x =>
                x.CodigoFornecedor == fornecedor.CodigoFornecedor &&
                x.Endereco.CodigoCidade == fornecedor.Endereco.CodigoCidade;

            var updateDefenition = Builders<Fornecedor>.Update
                .SetOnInsert(x => x.CodigoFornecedor, fornecedor.CodigoFornecedor)
                .Set(x => x.DescricaoFornecedor, fornecedor.DescricaoFornecedor)
                .Set(x => x.Cnpj, fornecedor.Cnpj)
                .Set(x => x.Email, fornecedor.Email)
                .Set(x => x.Endereco, fornecedor.Endereco);

            await _contexto.Collection.UpdateOneAsync(filtro, updateDefenition, new UpdateOptions
            {
                IsUpsert = true

            });
            return fornecedor;
        }

        public async Task Excluir(Fornecedor fornecedor)
        {
            Expression<Func<Fornecedor, bool>> filtro = x =>
                x.CodigoFornecedor == fornecedor.CodigoFornecedor &&
                x.Endereco.CodigoCidade == fornecedor.Endereco.CodigoCidade;

            await _contexto.Collection.DeleteOneAsync(filtro);
        }
    }
}
