namespace MyBlogWebAPI.Util.ApiResult
{
    public static class ApiResultHelper
    {
        public static ApiResult Success(dynamic data)
        {
            return new ApiResult
            {
                Code = 200,
                Data = data,
                Msg = "操作成功",
                Total = 0,
            };
        }
        public static ApiResult Success(dynamic data,int page)
        {
            return new ApiResult
            {
                Code = 200,
                Data = data,
                Msg = "操作成功",
                Total = page,
            };
        }

        public static ApiResult Error(string msg) { 
        
            return new ApiResult 
            { 
                Code=500,
                Msg = msg,
                Total=0,
                Data=null};
        }
    }
}
