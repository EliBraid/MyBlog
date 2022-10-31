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
    }
}
