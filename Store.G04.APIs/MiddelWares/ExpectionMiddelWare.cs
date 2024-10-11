using Store.G04.APIs.Error;
using System.Text.Json;

namespace Store.G04.APIs.MiddelWares
{
    public class ExpectionMiddelWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExpectionMiddelWare> _logger;
        private readonly IHostEnvironment _env;

        public ExpectionMiddelWare(RequestDelegate next, ILogger<ExpectionMiddelWare> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsyn(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var response = _env.IsDevelopment() ?
                    new ApiExpectionResponse(StatusCodes.Status500InternalServerError, ex.Message, ex?.StackTrace?.ToString())
                    : new ApiExpectionResponse(StatusCodes.Status500InternalServerError);

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
