using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CSBHService.Infra.InversaoDeControle
{
    public static class MongoDependency
    {
        public static void AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMongoDatabase>(c =>
            {

                // var connerctionString = "mongodb://localhost:27017";
                // var database = "Mongo_Asp_Net";

                var connerctionString = configuration["MongoDB:connectionString"];
                var database = configuration["MongoDB:database"];

                var cliente = new MongoClient(connerctionString);

                return cliente.GetDatabase(database);
            });
        }
    }
}
