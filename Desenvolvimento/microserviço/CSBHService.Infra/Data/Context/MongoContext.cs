using CSBHService.Dominio.Entidades;
using MongoDB.Driver;

namespace CSBHService.Infra.Data.Context
{
    public class MongoContext<TEntity> where TEntity : Entidade
    {
        private readonly IMongoDatabase _database;
        private readonly string _collection;

        public MongoContext(IMongoDatabase database, string collection)
        {
            _database = database;
            _collection = collection;
        }

        public IMongoCollection<TEntity> Collection =>
            _database.GetCollection<TEntity>(_collection);
    }
}
