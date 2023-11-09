using BeautyScheduler.Api.Helpers;
using BeautyScheduler.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace BeautyScheduler.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger _logger;



        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BeautySchedulerException ex)
            {
                context.Response.StatusCode = ex.StatusCode;
                await context.Response.WriteAsJsonAsync(new Response
                {
                    Code = ex.StatusCode,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                this._logger.LogError($"{ex}\n\n");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new Response
                {
                    Code = 500,
                    Message = ex.Message
                });
            }
        }
    }
}
