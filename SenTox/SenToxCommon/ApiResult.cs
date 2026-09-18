using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenToxCommon
{
    /// <summary>
    /// 统一API返回包装
    /// </summary>
    public class ApiResult<T>
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public T? Data { get; set; }

        public static ApiResult<T> Success(T? data, string msg = "success")
        {
            return new ApiResult<T>
            {
                Code = 200,
                Msg = msg,
                Data = data
            };
        }

        public static ApiResult<T> Fail(string msg, int code = 500)
        {
            return new ApiResult<T>
            {
                Code = code,
                Msg = msg,
                Data = default
            };
        }
    }

    /// <summary>
    /// 无Data返回
    /// </summary>
    public class ApiResult : ApiResult<object>
    {
        public static ApiResult Success(string msg = "success")
        {
            return new ApiResult
            {
                Code = 200,
                Msg = msg
            };
        }
    }
}
