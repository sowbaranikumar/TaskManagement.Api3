using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using TaskManagement.Business.ResponseModels;

namespace TaskManagement.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Unhandled exception while processing request {Method} {Path}",
                    context.Request.Method,
                    context.Request.Path);

                var (statusCode, response) = MapExceptionToApiResponse(ex, _env);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;

                var options=new JsonSerializerOptions
                {
                   // PropertyNamingPolicy=JsonNamingPolicy.CamelCase
                };

                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }
        }
        private static (int statusCode, object response) MapExceptionToApiResponse(Exception ex, IHostEnvironment env)
        {
            switch (ex)
            {
                case UnauthorizedAccessException:
                    return ((int)HttpStatusCode.Unauthorized,
                        ApiResponseFactory.BadRequest<string>(new List<string> { "Unauthorized" }));
                case ValidationException:
                    return ((int)HttpStatusCode.BadRequest,
                        ApiResponseFactory.BadRequest<string>(new List<string> { ex.Message }));
                default:
                    var msg = "An unexpected error occurred. Please try again later.";
                    if (env.IsDevelopment())
                        msg = $"{msg} | {ex.Message}";

                    return ((int)HttpStatusCode.InternalServerError,
                        ApiResponseFactory.BadRequest<string>(new List<string> { msg }));
            }
        }
    }
}

