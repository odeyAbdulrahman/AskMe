using AskMe.API.Domain.Entities;
using MongoDB.Driver;

namespace AskMe.API.Repository
{
    public interface IAppDbContext
    {
        IMongoCollection<Question> QuestionCollection { get; }
    }
}
