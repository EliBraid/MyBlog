using System.Linq.Expressions;

namespace MyBlog.IService
{
    public interface IBaseService<TEntity> where TEntity : class,new()
    {
        Task CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(int id);

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> FindByIdAsync(int id);
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> FindAll();
        /// <summary>
        /// 自定义条件查询
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> func);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="skip">跳过行数</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns></returns>
        Task<List<TEntity>> QueryPage(int skip, int pageSize);
        /// <summary>
        /// 自定义分页查询
        /// </summary>
        /// <param name="func"></param>
        /// <param name="skip"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<List<TEntity>> QueryPage(Expression<Func<TEntity, bool>> func, int skip, int pageSize);
    }
}