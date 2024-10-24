
namespace MIddlewares.CustomMiddlewares
{
    public class MyMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Custom Middleware Started!\n\n");
            await next(context);
            await context.Response.WriteAsync("Custom Middleware Finished!\n\n");
        }
    }


    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder MyMiddleware(this IApplicationBuilder app) 
        {
            return app.UseMiddleware<MyMiddleware>();    
        }
    }
}
