using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Core.Middleware
{
    public class GlobalExceptionMiddleware
    {
        #region Fields
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        #endregion

        #region Constructors
        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        #endregion

        #region Methods
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred while processing the request.");
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var response = ex.Message;
                await context.Response.WriteAsync(response);
            }
        }
        #endregion
    }
}


