using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.IRepository
{
    public interface IAuthorRepository:IBaseRepository<Author>
    {
        void Write();
    }
}
