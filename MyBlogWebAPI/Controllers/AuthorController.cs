using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;
using MyBlog.Model.DTO;
using MyBlogWebAPI.Util._MD5;
using MyBlogWebAPI.Util.ApiResult;

namespace MyBlogWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
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

        [HttpPut("Edit")]
        public async Task<ApiResult> Edit(string name)
        {
            int id = Convert.ToInt32(this.User.FindFirst("Id").Value);
            var author = await _service.FindByIdAsync(id);
            author.Account = name;
            await _service.UpdateAsync(author);
            return ApiResultHelper.Success(author);
        }

        [HttpGet("FindWriter")]

        public async Task<ApiResult> FindWriter(int id)
        {
            var writer = await _service.FindByIdAsync(id);
            var writerdto = _mapper.Map<AuthorDTO>(writer);

            return ApiResultHelper.Success(writerdto);
        }


    }
}
