using Microsoft.EntityFrameworkCore;
using MyBlog.IRepository;
using MyBlog.Model;
using MyBlog.Repository.DbContexts;
using System.Linq.Expressions;

namespace MyBlog.Repository
{
    public class BaseRepository<TEntity> : DbContext,IBaseRepository<TEntity> where TEntity : class,new()
    {
        protected readonly BlogDbContext _dbContext;

        public DbSet<TEntity> entities { get { 
                return _dbContext.Set<TEntity>();
            }}

        public BaseRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(TEntity entity)
        {
             entities.Add(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> FindAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> func)
        {
            return await _dbContext.Set<TEntity>().AsQueryable().Where(func).ToListAsync();
        }

        public async Task<List<TEntity>> QueryPage(int skip, int pageSize)
        {
           return await _dbContext.Set<TEntity>().Skip(skip).Take(pageSize).ToListAsync();
        }

        public async Task<List<TEntity>> QueryPage(Expression<Func<TEntity, bool>> func, int skip, int pageSize)
        {
            return await _dbContext.Set<TEntity>().AsQueryable().Where(func).Skip(skip).Take(pageSize).ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
             await _dbContext.SaveChangesAsync();
        }

    }
}