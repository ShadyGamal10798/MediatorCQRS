using Npgsql;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace MediatorCQRS.Helpers.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        void Attach(T entity);

        void AttachRange(IEnumerable<T> entities);
        Task<bool> CheckAnyAsync(Expression<Func<T, bool>> condition);
        Task CreateAsync(T entity);
        IQueryable<T> FindAllAsQuerable();
        IQueryable<T> FindAllQuerable(params Expression<Func<T, object>>[] includes);
        Task<List<T>> FindAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, Expression<Func<T, object>>? orderBy = null, bool isDescending = false);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, Expression<Func<T, object>>? orderBy = null, bool isDescending = false, int pageSize = 0, int pageNumber = 1);
        Task<IEnumerable<TResult>> SelectAsync<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>? orderBy = null, bool isDescending = false);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null);
        Task<int> GetCountAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> GetLast<TKey>(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null, Expression<Func<T, TKey>> orderBy = null);
        Task<T> GetLastAsync<TKey>(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null, Expression<Func<T, TKey>> orderBy = null);
        Task RemoveAsync(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void MarkAsRemoved(T entity);
        Task<IEnumerable<T>> ExecuteSql(string sqlQuery, object parameters = null);

        Task<List<T>> ExecuteSqlWithParams(string sqlQuery, params NpgsqlParameter[] parameters);

        void Update(T entity);

        Task<T> ExecuteSqlFirstAsync(string sqlQuery, object parameters = null);
        Task ReloadAsync(T entity);

        void Deatach(T entity);
        Task<T> ExecuteOneSqlRaw(string sqlQuery);
    }





}
