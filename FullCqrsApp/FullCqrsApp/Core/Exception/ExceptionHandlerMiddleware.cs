using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using FullCqrsApp.Core.Exception.Exceptions;
using Microsoft.AspNetCore.Http;

namespace FullCqrsApp.Core.Exception
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (System.Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, System.Exception exception)
        {
            var statusCode = GetStatusCode(exception);

            var response = new
            {
                title = GetTitle(exception),
                status = statusCode,
                detail = exception.Message,
                errors = GetErrors(exception)
            };

            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static int GetStatusCode(System.Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };

        private static string GetTitle(System.Exception exception) =>
            exception switch
            {
                ApplicationException applicationException => applicationException.Title,
                _ => "Server Error"
            };

        private static IReadOnlyDictionary<string, string[]> GetErrors(System.Exception exception)
        {
            IReadOnlyDictionary<string, string[]> errors = null;

            if (exception is ValidationException validationException)
            {
                errors = validationException.ErrorsDictionary;
            }

            return errors;
        }
    }
}