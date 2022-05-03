using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MiddlewareNet5
{
    public class LoggingMiddleware
    {

        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await WriteDataToFile(context);

            await _next(context);
        }

        public static async Task WriteDataToFile(HttpContext context)
        {
            string[] lines = {
                "Scheme: " + context.Request.Scheme,
                "Host: " + context.Request.Host.ToString(),
                "Path: " + context.Request.Path.ToString(),
                "Query String: " + context.Request.QueryString.ToString(),
                "Request Body: " + context.Request.Body,
            };

            await File.WriteAllLinesAsync("logdata.txt", lines);
        }
    }

    public static class LoggingMiddleWare
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}