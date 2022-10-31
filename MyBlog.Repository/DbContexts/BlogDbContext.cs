using Microsoft.EntityFrameworkCore;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Repository.DbContexts
{
    public class BlogDbContext: DbContext
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<BlogNews> BlogNews { get; set; }
        public DbSet<TypeId> TypeId { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options):base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"server=1.116.234.172;uid=sa;pwd=Ww1632050253.;database=Blog;TrustServerCertificate=true");
        //}
    }
}
