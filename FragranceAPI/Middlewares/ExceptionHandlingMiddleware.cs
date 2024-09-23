using Application.Exceptions;
using System.Text.Json;

namespace FragranceAPI.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var result = JsonSerializer.Serialize(new { message = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex is AppException ? StatusCodes.Status400BadRequest : StatusCodes.Status500InternalServerError;
            return context.Response.WriteAsync(result);
        }
    }

}
