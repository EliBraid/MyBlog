using Microsoft.EntityFrameworkCore.Metadata;
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
    public class TypeIdRepository : BaseRepository<TypeInfo>, ITypeIdRepository
    {
        public TypeIdRepository(BlogDbContext dbContext) : base(dbContext)
        {
        }

        public void Method()
        {
            throw new NotImplementedException();
        }
    }
}
