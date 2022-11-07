using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using MyBlog.IService;
using MyBlog.Model;
using MyBlogWebAPI.Util.ApiResult;
using System.Text.Json;

namespace MyBlogWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogNewService _blognewservice;
        private readonly IMemoryCache _cache;
        private readonly IDistributedCache _distributedCache;
        public BlogsController(IBlogNewService blogNewService, IMemoryCache cache, IDistributedCache distributedCache)
        {
                _blognewservice = blogNewService;
                _cache = cache;
                _distributedCache = distributedCache;
        }

        [HttpGet("BlogNews")]
        public async Task<List<BlogNews>> GetBlogNews()
        {
            Console.WriteLine("开始查询所有数据");
            //var data = _cache.GetOrCreateAsync("ALL",async (e) =>
            //{
            //    e.SlidingExpiration = TimeSpan.FromSeconds(10);
            //    Console.WriteLine("缓存没有，到数据库里查");
            //    return await _blognewservice.FindAll();
            //}
            //).Result;
            List<BlogNews> list;

            var data = await _distributedCache.GetStringAsync("All");

            if(data == null)
            {
                list = await _blognewservice.FindAll();
                Console.WriteLine("查询数据库");
                _distributedCache.SetStringAsync("All", JsonSerializer.Serialize(list));
            }
            else
            {
                list = JsonSerializer.Deserialize<List<BlogNews>>(data);
            }
            return list;
        }
        
        [HttpPost("BlogCreate")]
        public async Task<ActionResult<ApiResult>> Create(string title,string content,int typeid,int authorId)
        {
            BlogNews blog = new BlogNews()
            {
                Title = title,
                Content = content,
                AuthorId = authorId,
                CreateTime= DateTime.Now,
                TypeInfoId = typeid,
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
            //blog.TypeId = typeid;

            await _blognewservice.UpdateAsync(blog);

            return ApiResultHelper.Success(blog);
        }

    }
}
