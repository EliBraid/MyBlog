namespace MyBlogWebAPI.Util.ApiResult
{
    public class ApiResult
    {   
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 分页页数
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 请求数据
        /// </summary>
        public dynamic Data { get; set; }

    }
}
