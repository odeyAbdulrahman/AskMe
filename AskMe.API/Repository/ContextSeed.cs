using AskMe.API.Domain.Entities;
using MongoDB.Driver;

namespace AskMe.API.Repository
{
    public class ContextSeed
    {
        public static void SeedData(IMongoCollection<Question> TahseelCollection)
        {
            bool ExistService = TahseelCollection.Find(x => true).Any();
            if (!ExistService)
            {
                TahseelCollection.InsertManyAsync(GetServices());
            }
        }

        private static IEnumerable<Question> GetServices()
        {
            return new List<Question>()
            {

            };
        }
    }
}
