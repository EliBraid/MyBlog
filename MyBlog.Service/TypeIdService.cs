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
    public class TypeIdService:BaseService<TypeId>,ITypeIdService
    {
        public TypeIdService(ITypeIdRepository repository)
        {
            base._repository = repository;
        }
    }
}
