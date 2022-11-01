using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;
using MyBlogWebAPI.Util.ApiResult;

namespace MyBlogWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogNewService _blognewservice;
        public BlogsController(IBlogNewService blogNewService)
        {
                _blognewservice = blogNewService;
        }

        [HttpGet("BlogNews")]
        public async Task<ActionResult<ApiResult>> GetBlogNews()
        {
            var data = _blognewservice.FindAll().Result;
            if (data.Count ==0) return ApiResultHelper.Error("没有更多的数据");
            return ApiResultHelper.Success(data);
        }

        [HttpPost("BlogCreate")]
        public async Task<ActionResult<ApiResult>> Create(string title,string content,int typeid)
        {
            BlogNews blog = new BlogNews()
            {
                Title = title,
                Content = content,
                AuthorId =1,
                CreateTime= DateTime.Now,
                TypeId = typeid,
                LikedCounts = 0,
                ViewsCounts= 0
            };
            await _blognewservice.CreateAsync(blog);
            return ApiResultHelper.Success(blog);
        }
        [HttpDelete("BlogDelete")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            await _blognewservice.DeleteAsync(id);

            return ApiResultHelper.Success(true);
        }

        [HttpPut("BlogUpdate")]
        public async Task<ActionResult<ApiResult>> Update(int id,string title,string content,int typeid)
        {
            var blog = _blognewservice.FindByIdAsync(id).Result;

            blog.Title = title;
            blog.Content = content;
            blog.TypeId = typeid;

            await _blognewservice.UpdateAsync(blog);

            return ApiResultHelper.Success(blog);
        }

    }
}
