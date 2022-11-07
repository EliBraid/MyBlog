using Microsoft.EntityFrameworkCore;
using MyBlog.IRepository;
using MyBlog.Model;
using MyBlog.Repository.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Repository
{
    public class BlogNewsRepository : BaseRepository<BlogNews>, IBlogNewsRepository
    {
        public BlogNewsRepository(BlogDbContext dbContext) : base(dbContext)
        {
            
        }

        public override async Task<List<BlogNews>> FindAll()
        {
            var blog =await _dbContext.Set<BlogNews>().Include(p => p.Author).Include(p=>p.TypeInfo).ToListAsync();
            return blog;
        }
    }
}
