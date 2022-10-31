using MyBlog.IRepository;
using MyBlog.IService;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service
{
    public class BlogNewService:BaseService<BlogNews>,IBlogNewService
    {
        public BlogNewService(IBlogNewsRepository repository)
        {
            base._repository = repository;
        }
    }
}
