using AskMe.API.Domain.Enumerations;

namespace AskMe.API.Services
{
    public interface IGenericNonSqlRepository<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> GetAsync(string? id);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>?> GetAllAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        Task<IEnumerable<T>?> GetAllAsync(DateTime FromDate, DateTime ToDate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        Task<FeedBackCode> InsertAsync(T entity, CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        Task<FeedBackCode> InsertAsync(IEnumerable<T> entity, CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        Task<FeedBackCode> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        Task<FeedBackCode> DeleteAsync(T entity, CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        Task<FeedBackCode> DeleteAsync(IEnumerable<T> entity, CancellationToken cancellationToken = default);
    }
}
