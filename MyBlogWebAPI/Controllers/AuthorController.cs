using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;
using MyBlogWebAPI.Util._MD5;
using MyBlogWebAPI.Util.ApiResult;

namespace MyBlogWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service; 
        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpPost("Create")]

        public async Task<ActionResult<ApiResult>> Create(string name, string account, string password)
        {
            Author author = new Author
            {
                Name = name,
                Account = account,
                Password = MD5Helper.MD5Encrypt32(password)
            };

            var oldauthor = await _service.FindAsync(c => c.Account == author.Account);
            if(oldauthor != null)
            {
                return ApiResultHelper.Error("账号已经存在");
            }
            else
            {
                await _service.CreateAsync(author);
                return ApiResultHelper.Success(author);
            }  
        }
    }
}
