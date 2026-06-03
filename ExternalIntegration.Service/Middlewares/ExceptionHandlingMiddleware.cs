using ExternalIntegration.Service.Application.Shared;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace ExternalIntegration.Service.Middlewares
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
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static async Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var root = GetRootException(ex);

            var message = root == ex
                ? ex.Message
                : $"{ex.Message} | Inner: {root.Message}";

            var response = Response<string>.Error(message);

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static Exception GetRootException(Exception ex)
        {
            while (ex.InnerException is not null)
                ex = ex.InnerException;

            return ex;
        }

    }
}
