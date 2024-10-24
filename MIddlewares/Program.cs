//Create amn instance of Web Application Builder
var builder = WebApplication.CreateBuilder(args);

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
    await httpContext.Response.WriteAsync("Hello There Mate!\n");
    await next(httpContext);
});


app.Run(async (HttpContext httpContext) =>
{
    await httpContext.Response.WriteAsync("Hello There Again!");
});


app.Run();
