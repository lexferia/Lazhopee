using System.Net;
using System.Text.Json;

namespace Lazhopee.API.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            var message = exception.Message;
            if (exception is HttpRequestException)
            {
                var httpRequestException = (HttpRequestException)exception;
                httpContext.Response.StatusCode = (int)httpRequestException.StatusCode;
            }
            else
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                message = $"Error encountered while processing request. Message: {exception.Message}";
            }

            var response = new
            {
                status = httpContext.Response.StatusCode,
                message = message
            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
