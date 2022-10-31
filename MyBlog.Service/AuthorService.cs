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
    public class AuthorService:BaseService<Author>,IAuthorService
    {
        public AuthorService(IAuthorRepository repository)
        {
            base._repository = repository;
        }
    }
}
