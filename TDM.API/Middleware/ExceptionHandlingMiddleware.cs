using System.Net;
using System.Text.Json;
using FluentValidation;
using TDM.API.Common.Models;

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
        catch (ValidationException ex)
        {
            await HandleValidationException(context, ex);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private static async Task HandleValidationException(HttpContext context, ValidationException ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";

        var errors = ex.Errors
            .GroupBy(x => x.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.ErrorMessage).ToArray()
            );

        var response = ApiResponse.Fail("Validation failed", errors);

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static async Task HandleException(HttpContext context, Exception ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var response = ApiResponse.Fail(ex.Message);

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
