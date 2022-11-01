using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;
using MyBlogWebAPI.Util.ApiResult;

namespace MyBlogWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeIdController : ControllerBase
    {
        private readonly ITypeIdService _service;
        public TypeIdController(ITypeIdService service)
        {
            _service = service;
        }

        [HttpGet("Types")]
        public async Task<ActionResult<ApiResult>> Gets()
        {
            var typeIdlist = _service.FindAll().Result;
            if (typeIdlist.Count == 0) return ApiResultHelper.Error("没有类型");
            return ApiResultHelper.Success(typeIdlist);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ApiResult>> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return ApiResultHelper.Error("名字不能为空");
            TypeId typeId = new TypeId()
            {
                TypeName = name
            };

            await _service.CreateAsync(typeId);

            return ApiResultHelper.Success(typeId);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ApiResult>> DeleteById(int id)
        {
            await _service.DeleteAsync(id);

            return ApiResultHelper.Success(true);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ApiResult>> UpdateById(int id,string name)
        {
            var typeid =  _service.FindByIdAsync(id).Result;
            typeid.TypeName = name;

            await _service.UpdateAsync(typeid);

            return ApiResultHelper.Success(typeid);
        }
    }
}
