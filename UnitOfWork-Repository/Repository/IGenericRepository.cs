using System.ComponentModel;
using System.Linq.Expressions;
using Task.Data.Entities;
using CTask = System.Threading.Tasks;

//contrevaiance and variance in generics

namespace Task.Repository
{
    public interface IRepository<TEntity, in TPrimaryKey> : IDisposable where TEntity : BaseEntity<TPrimaryKey>
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);

        Task<List<TEntity>> GetAllList();

        Task<List<TEntity>> GetAllListIncluding(params Expression<Func<TEntity, object>>[] includeProperties);

        ValueTask<TEntity> Find(TPrimaryKey id);

        Task<TEntity> GetFirst(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        Task<bool> Any(Expression<Func<TEntity, bool>> predicate);

        Task<bool> All(Expression<Func<TEntity, bool>> predicate);

        Task<int> Count();

        Task<int> Count(Expression<Func<TEntity, bool>> predicate);

        CTask.Task Add(TEntity entity);

        CTask.Task Update(TEntity entity);

        CTask.Task Delete(TEntity entity);

        CTask.Task DeleteWhere(Expression<Func<TEntity, bool>> predicate);

        CTask.Task Commit(CancellationToken cancellationToken = default);
    }
}