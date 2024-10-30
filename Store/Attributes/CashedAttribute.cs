using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.Core.Services.Contract;
using System.Text;

namespace Store.Attributes
{
    public class CashedAttribute:Attribute,IAsyncActionFilter
    {
        private readonly int _expireTime;

        public CashedAttribute(int expireTime)
        {
            _expireTime = expireTime;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cachedService= context.HttpContext.RequestServices.GetRequiredService<ICasheService>();
            var cacheKey = GenerateCachedKeyFromRequest(context.HttpContext.Request);
            var cashResponce=await cachedService.GetCasheAsync(cacheKey);
            if (!string.IsNullOrEmpty(cashResponce))
            {
                var contanResult = new ContentResult()
                {
                    Content = cashResponce,
                    ContentType = "application/json",
                    StatusCode = 200,
                };
                context.Result = contanResult;
                return;
            }
            var excutedContext=await next();
            if (excutedContext.Result is OkObjectResult response)
            {
                await cachedService.SetCasheAsync(cacheKey,response.Value,TimeSpan.FromSeconds(_expireTime));
            }
        }
        private string GenerateCachedKeyFromRequest(HttpRequest request)
        {
            var cacheKey=new StringBuilder();
            cacheKey.Append($"{request.Path}");
            foreach (var (key,value) in request.Query.OrderBy(x=>x.Key))
            {
                cacheKey.Append($"{key}-{value}");
            }
            return cacheKey.ToString();
        }
    }
}
