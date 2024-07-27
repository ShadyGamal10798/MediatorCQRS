using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Linq.Expressions;
using System.Linq;
using System.Xml.Linq;
using MediatorCQRS.DatabaseContext;
using MediatorCQRS.Helpers.Interfaces;

namespace MediatorCQRS.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly NaqleenDBContext _db;
        internal DbSet<T> dbSet;
        private readonly IConfiguration _config;
        public Repository(NaqleenDBContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
            this.dbSet = _db.Set<T>();

        }
        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }


        public void Update(T entity)
        {
            dbSet.Update(entity);
            //dbSet.Attach(entity);
            //_db.Entry(entity).State = EntityState.Modified;

        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return await query.FirstOrDefaultAsync();
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null,
            Expression<Func<T, object>>? orderBy = null, bool isDescending = false, int pageSize = 0, int pageNumber = 1)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
            {
                if (isDescending)
                {
                    query = query.OrderByDescending(orderBy);
                }
                else
                {
                    query = query.OrderBy(orderBy);
                }
            }
            if (pageSize > 0)
            {
                if (pageSize > 100)
                {
                    pageSize = 100;
                }
                query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);

            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }


            return await query.ToListAsync();
        }
        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null, Expression<Func<T, object>>? orderBy = null, bool isDescending = false
            )

        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                if (isDescending)
                {
                    query = query.OrderByDescending(orderBy);
                }
                else
                {
                    query = query.OrderBy(orderBy);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TResult>> SelectAsync<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>? orderBy = null, bool isDescending = false)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                if (isDescending)
                {
                    query = query.OrderByDescending(orderBy);
                }
                else
                {
                    query = query.OrderBy(orderBy);
                }
            }
            return await query.Select(selector).ToListAsync();

        }
        public async Task<int> GetCountAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.CountAsync();
        }
        public async Task RemoveAsync(T entity)
        {
            dbSet.Remove(entity);

        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return entities;
        }
        public void Attach(T entity)
        {
            dbSet.Attach(entity);
        }
        public void MarkAsRemoved(T entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
        }
        public void AttachRange(IEnumerable<T> entities)
        {
            dbSet.AttachRange(entities);
        }
        public IQueryable<T> FindAllAsQuerable()
        {
            var query = _db.Set<T>().AsQueryable();
            return query;
        }
        public IQueryable<T> FindAllQuerable(params Expression<Func<T, object>>[] includes)
        {
            var query = _db.Set<T>().AsQueryable();

            query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));


            return query;
        }

        public async Task<bool> CheckAnyAsync(Expression<Func<T, bool>> condition)
        {
            return await dbSet.AnyAsync(condition);
        }

        public async Task<T> GetLastAsync<TKey>(
        Expression<Func<T, bool>> filter = null,
        bool tracked = true,
        string? includeProperties = null,
        Expression<Func<T, TKey>> orderBy = null
        )
        {
            IQueryable<T> query = dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                query = query.OrderBy(orderBy);
            }

            return await query.LastOrDefaultAsync();

        }
        public async Task<T> GetLast<TKey>(
       Expression<Func<T, bool>> filter = null,
       bool tracked = true,
       string? includeProperties = null,
       Expression<Func<T, TKey>> orderBy = null
       )
        {
            IQueryable<T> query = dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                query = query.OrderBy(orderBy);
            }
            return query.LastOrDefault();

        }

        public async Task<IEnumerable<T>> ExecuteSql(string sqlQuery, object parameters = null)
        {
            if (parameters == null)
                return await _db.Set<T>().FromSqlRaw(sqlQuery).ToListAsync();

            return await _db.Set<T>().FromSqlRaw(sqlQuery, parameters).ToListAsync();

        }

        public async Task<List<T>> ExecuteSqlWithParams(string sqlQuery, params NpgsqlParameter[] parameters)
        {
            if (parameters == null || parameters.Length == 0)
                return await _db.Set<T>().FromSqlRaw(sqlQuery).ToListAsync();

            return await _db.Set<T>().FromSqlRaw(sqlQuery, parameters).ToListAsync();
        }

        public async Task<T> ExecuteSqlFirstAsync(string sqlQuery, object parameters = null)
        {
            if (parameters == null)
            {
                var res = await _db.Set<T>().FromSqlRaw(sqlQuery).ToListAsync();
                return res.FirstOrDefault();
            }

            var result = await _db.Set<T>().FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return result.FirstOrDefault();

        }
        public async Task ReloadAsync(T entity)
        {
            await _db.Entry(entity).ReloadAsync();
        }

        public void Deatach(T entity)
        {
            _db.Entry(entity).State = EntityState.Detached;
        }
        public async Task<T> ExecuteOneSqlRaw(string sqlQuery)
        {
            var res = await _db.Set<T>().FromSqlRaw(sqlQuery).FirstOrDefaultAsync();
            return res;

        }
    }
}
