using Store.Error;
using System.Text.Json;

namespace Store.Middlewares
{
    public class ExeptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExeptionsMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExeptionsMiddleware(RequestDelegate next,ILogger<ExeptionsMiddleware> logger,IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var response = _env.IsDevelopment() ?
                    new ApiExseptionResponse(StatusCodes.Status500InternalServerError, ex.Message, ex?.StackTrace?.ToString())
                :new ApiExseptionResponse(StatusCodes.Status500InternalServerError);
                var option = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                var json= JsonSerializer.Serialize(response,option);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
