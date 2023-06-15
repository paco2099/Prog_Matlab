using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Text.Json;

namespace WebAPI
{
    public class CustomExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // No es necesario realizar ninguna acción antes de la ejecución del controlador
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                var errorResponse = new
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    Title = "uy.",
                    Status = StatusCodes.Status400BadRequest,
                    TraceId = context.HttpContext.TraceIdentifier,
                    Errors = new
                    {
                        ErrorMessage = context.Exception.Message,
                        ExceptionType = context.Exception.GetType().Name
                    }
                };

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };

                var json = JsonSerializer.Serialize(errorResponse, options);

                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.HttpContext.Response.ContentType = "application/json";
                context.Result = new ContentResult
                {
                    Content = json,
                    StatusCode = StatusCodes.Status400BadRequest,
                    ContentType = "application/json"
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
