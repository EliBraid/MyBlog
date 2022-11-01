using AutoMapper;
using MyBlog.Model;
using MyBlog.Model.DTO;

namespace MyBlogWebAPI.Util._AutoMapper
{
    public class CustomAutoMapperProfile: Profile
    {
        public CustomAutoMapperProfile()
        {
            base.CreateMap<Author, AuthorDTO>();
        }
    }
}
