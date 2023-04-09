using AskMe.API.Domain.Entities;
using MongoDB.Driver;

namespace AskMe.API.Repository
{
    public class AppDbContext : IAppDbContext
    {
        public AppDbContext(IConfiguration configuration)
        {
            var conn = $"{configuration.GetValue<string>("DataBaseSettings:ConnectionString")}{configuration.GetValue<string>("DataBaseSettings:Trusted_Connection")}";
            var client = new MongoClient(conn);
            var dataBase = client.GetDatabase(configuration.GetValue<string>("DataBaseSettings:DatabaseName"));
            QuestionCollection = dataBase.GetCollection<Question>(configuration.GetValue<string>("DataBaseSettings:CollectionName"));
            ContextSeed.SeedData(QuestionCollection);
        }
        public IMongoCollection<Question> QuestionCollection { get; }
    }
}
