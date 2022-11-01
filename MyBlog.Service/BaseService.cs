using MyBlog.IRepository;
using MyBlog.IService;
using System.Linq.Expressions;

namespace MyBlog.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        protected IBaseRepository<TEntity> _repository;
        public async Task CreateAsync(TEntity entity)
        {
            await _repository.CreateAsync(entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public virtual async Task<List<TEntity>> FindAll()
        {
           return await _repository.FindAll();
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func)
        {
            return await _repository.FindAsync(func);
        }

        public virtual async Task<TEntity> FindByIdAsync(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public virtual async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> func)
        {
            return await _repository.Query(func);
        }

        public virtual Task<List<TEntity>> QueryPage(int skip, int pageSize)
        {
            return _repository.QueryPage(skip, pageSize);
        }

        public virtual Task<List<TEntity>> QueryPage(Expression<Func<TEntity, bool>> func, int skip, int pageSize)
        {
            return _repository.QueryPage(func, skip, pageSize);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}