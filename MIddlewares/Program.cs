

//Create amn instance of Web Application Builder
using MIddlewares.CustomMiddlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MyMiddleware>();

//Create amn instance of Web Application
var app = builder.Build();

//Defining Routes (Get Methods)
//app.MapGet("/", () => "Hello World!");


//This is basic middleware. every request hits this ,iddleware.... but this cannot be chained
//app.Run(async(HttpContext httpContext) => {
//    await httpContext.Response.WriteAsync("Hello There!");
//});

app.Use(async (HttpContext httpContext, RequestDelegate next) =>
{
    await httpContext.Response.WriteAsync("Hello There Mate!\n\n");
    await next(httpContext);
});


//app.UseMiddleware<MyMiddleware>();
app.MyMiddleware();
app.UseAnotherCustomMiddleware();


app.UseWhen(context => context.Request.Query.ContainsKey("IsAuthorized") && context.Request.Query["IsAuthorized"] == "true",
    app =>
    app.Use(async (HttpContext httpContext, RequestDelegate next) =>
    {
        await httpContext.Response.WriteAsync("Conditional Middleware Called!\n\n");
        await next(httpContext);
    })
    );

app.Run(async (HttpContext httpContext) =>
{
    await httpContext.Response.WriteAsync("Hello There Again!\n\n");
});


app.Run();
