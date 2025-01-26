using System.Net;
using DesafioNET.Models;

namespace DesafioNET.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        private readonly ILogger logger;

        private readonly IHostEnvironment env;
        public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware>logger,IHostEnvironment env) 
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        async public Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex) 
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = env.IsDevelopment() ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString()) : new ApiException(context.Response.StatusCode, "Internal Server Error");
            }
        }
    }
}
