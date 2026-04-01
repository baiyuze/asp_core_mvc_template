using WebApplication1.Routes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();



var app = builder.Build();

app.MapGet("/", () => Results.Ok(new
{
    message = "Service is running",
    endpoints = new[]
    {
        "/api/v1/test"
    }
}));

app.MapGroup("/api/v1").RouteStart();

// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// app.Logger.LogInformation("Server is running..., Please visit http://localhost:5000");

app.Run();
