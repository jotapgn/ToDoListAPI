using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Bson;
using ToDoList.Core.Repositories;
using ToDoList.Infrastructure.Persistence.Repositories;
using ToDoList.Infrastructure.Persistence;

namespace ToDoList.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongo(configuration);
            services.AddRepositoriy();
            return services;
        }
        public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            var mongo = configuration.GetSection("Mongo");
            services.Configure<MongoDbOptions>(mongo);
            CreateDb(mongo);
            return services;
        }
        public static void CreateDb(IConfigurationSection mongo)
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

            var mongoDbOptions = new MongoDbOptions();
            mongo.Bind(mongoDbOptions);

            var client = new MongoClient(mongoDbOptions.ConnectionString);
            IMongoDatabase? db = client.GetDatabase(mongoDbOptions.Database);
            var dbSeed = new DbSeed(db);
            dbSeed.Populate();
        }
        private static IServiceCollection AddRepositoriy(this IServiceCollection services)
        {
            services.AddScoped<IToDoRepository, ToDoRepository>();
            return services;
        }
    }
}
