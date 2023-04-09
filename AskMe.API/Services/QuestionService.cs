using AskMe.API.Domain.Entities;
using AskMe.API.Domain.Enumerations;
using AskMe.API.Repository;
using MongoDB.Driver;

namespace AskMe.API.Services
{
    public class QuestionService: IQuestion
    {
        private readonly IAppDbContext Context;

    public QuestionService(IAppDbContext context)
    {
        Context = context;
    }

    public async Task<Question?> GetAsync(string? id)
    {
        return await Context.QuestionCollection.FindAsync(x => x.Id == id).GetAwaiter().GetResult().FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<Question>?> GetAllAsync()
    {
        return await Context.QuestionCollection.FindAsync(_ => true).GetAwaiter().GetResult().ToListAsync();
    }
    public async Task<IEnumerable<Question>?> GetAllAsync(DateTime FromDate, DateTime ToDate)
    {
        return await Context.QuestionCollection.FindAsync(x => x.CreatedDate >= FromDate && x.CreatedDate <= ToDate).GetAwaiter().GetResult().ToListAsync();
    }
    public async Task<FeedBackCode> InsertAsync(Question entity, CancellationToken cancellationToken = default)
    {
        await Context.QuestionCollection.InsertOneAsync(entity, cancellationToken);
        return FeedBackCode.Created;
    }
    public async Task<FeedBackCode> InsertAsync(IEnumerable<Question> entity, CancellationToken cancellationToken = default)
    {
        await Context.QuestionCollection.InsertManyAsync(entity, null, cancellationToken);
        return FeedBackCode.Created;
    }
    public async Task<FeedBackCode> UpdateAsync(Question entity, CancellationToken cancellationToken = default)
    {
        var Result = await Context.QuestionCollection.ReplaceOneAsync(filter: x => x.Id == entity.Id, replacement: entity, cancellationToken: cancellationToken);
        return Result.IsAcknowledged && Result.ModifiedCount > 0 ? FeedBackCode.Updated : FeedBackCode.NotUpdated;
    }
    public async Task<FeedBackCode> DeleteAsync(Question entity, CancellationToken cancellationToken = default)
    {
        DeleteResult Result = await Context.QuestionCollection.DeleteOneAsync(filter: x => x.Id == entity.Id, cancellationToken);
        return Result.IsAcknowledged && Result.DeletedCount > 0 ? FeedBackCode.Deleted : FeedBackCode.NotDeleted;
    }
    public async Task<FeedBackCode> DeleteAsync(IEnumerable<Question> entitys, CancellationToken cancellationToken = default)
    {
        FilterDefinition<Question> Filter = Builders<Question>.Filter.Where(x => entitys.Select(x => x.Id).Contains(x.Id));
        DeleteResult Result = await Context.QuestionCollection.DeleteManyAsync(Filter, cancellationToken);
        return Result.IsAcknowledged && Result.DeletedCount > 0 ? FeedBackCode.Deleted : FeedBackCode.NotDeleted;
    }
}
}
