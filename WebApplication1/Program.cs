using System.Reflection;
using WebApplication1.Routes;

using WebApplication1.Infrastructure;
using WebApplication1.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure();
builder.Services.AddInfrastructureAuth(builder.Configuration);


var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseStatusCodePages(( context) => Message.DefineMessage(context));

app.MapGroup("/api/v1").MapRouteGroups();
app.Run();
