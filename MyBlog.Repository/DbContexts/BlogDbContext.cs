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
        public DbSet<TypeInfo> TypeId { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogNews>().HasData(
                new BlogNews
                {
                    AuthorId = 1,
                    Content = "小说你写的",
                    CreateTime= DateTime.Now,
                    LikedCounts= 0,
                    ViewsCounts= 0,
                    Id=1,
                    Title = "是你的",
                    TypeInfoId= 1
                },
                new BlogNews
                {
                    AuthorId = 1,
                    Content = "不死小说",
                    CreateTime = DateTime.Now,
                    LikedCounts = 0,
                    ViewsCounts = 0,
                    Id = 2,
                    Title = "而现在",
                    TypeInfoId = 1
                }
                );
        }
    }
}
