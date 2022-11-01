using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyBlog.IService;
using MyBlog.JWT.Util._MD5;
using MyBlog.JWT.Util.ApiResult;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyBlog.JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoizeController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthoizeController(IAuthorService service)
        {
            _service = service;
        }

        [HttpPost("Login")]
        public async Task<ApiResult> Login(string name,string password)
        {
            string pwd = MD5Helper.MD5Encrypt32(password);

           var author = await _service.FindAsync(c => c.Account == name && c.Password == pwd);
        
            if(author != null)
            {
                //登录成功
                var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, author.Name),
                new Claim("Id",author.Id.ToString()),
                new Claim("UserName",author.Account.ToString())

                //里面不能放入敏感信息
            };
                //密钥
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SDMC-CJAS1-SAD-DFSFA-SADHJVF-VF"));
                //issuer代表颁发Token的Web应用程序，audience是Token的受理者
                var token = new JwtSecurityToken(
                    issuer: "http://localhost:6060",
                    audience: "http://localhost:5000",
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                return ApiResultHelper.Success(jwtToken);
            }
            else
            {
                return ApiResultHelper.Error("账号密码错误");
            }
        }

    }
}
