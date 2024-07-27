using MediatorCQRS.DatabaseContext;
using MediatorCQRS.Services;
using Microsoft.EntityFrameworkCore.Storage;

namespace MediatorCQRS.Helpers.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContextTransaction BeginTransaction();
        void Commit();
        void Dispose();
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void RollBack();
        Task SaveAsync(); // Add SaveAsync method to save changes in the database.
    }


    public class UnitOfWork : IUnitOfWork
    {
        private readonly NaqleenDBContext _dbContext;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        private readonly IConfiguration _configuration;
        public UnitOfWork(NaqleenDBContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var entityType = typeof(TEntity);
            if (!_repositories.TryGetValue(entityType, out var repository))
            {
                var repositoryType = typeof(Repository<>).MakeGenericType(entityType);
                repository = Activator.CreateInstance(repositoryType, _dbContext, _configuration);

                _repositories.Add(entityType, repository);
            }

            return (IRepository<TEntity>)repository;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }
        public void Commit()
        {
            _dbContext.Database.CommitTransaction();
            _dbContext.SaveChanges();
        }

        public void RollBack()
        {
            _dbContext.Database.RollbackTransaction();
        }
    }
}
