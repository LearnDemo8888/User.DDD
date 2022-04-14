
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using User.DDD.Core;

namespace User.DDD.WebApi.Filters
{
    public class PreventDuplicateSubmitAttribute : ActionFilterAttribute
    {



        /// <summary>
        /// https://stackoverflow.com/questions/58336505/why-my-request-bodyreader-is-empty-when-i-add-request-parameters-asp-net-core-3
        /// </summary>
        /// <param name="context"></param>



        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var httpContext = context.HttpContext;
            var cache = context.HttpContext.RequestServices.GetService<IDistributedCache>();

            string httpMethod = httpContext.Request.Method;

            string path = httpContext.Request.Path;

            if (!httpMethod.Contains("GET", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(path))
            {
                var argStr = GetRawBodyString(httpContext.Request);
                if (httpContext.Request.Query.Keys.Count > 0)
                {
                    argStr = $"{argStr}_{httpContext.Request.QueryString}";

                }
                var md5Key = MD5Helper.MD5Encrypt16($"{path}:{argStr}");

                var value = cache.GetString(md5Key);

                if (string.IsNullOrEmpty(value))
                {
                    cache.SetString(md5Key, argStr, new DistributedCacheEntryOptions()
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                    });
                }
                else
                {
                    context.Result = new BadRequestObjectResult("请不要重复提交");

                }

            }

        }



        private string GetRawBodyString(HttpRequest request)
        {

            request.Body.Seek(0, SeekOrigin.Begin);
            using StreamReader reader = new StreamReader(request.Body);
            return reader.ReadToEnd();
        }

    }



}
