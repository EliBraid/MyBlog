using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.IRepository
{
    public interface ITypeIdRepository:IBaseRepository<TypeInfo>
    {
        void Method();
    }
}
