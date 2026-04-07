using System.Reflection;
using WebApplication1.Routes;
using WebApplication1.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure();
var app = builder.Build();

 
app.MapGroup("/api/v1").MapRouteGroups();
app.Run();
//
// // 1. 定义模块化接口
// public interface IEndpointModule
// {
//     void Map(IEndpointRouteBuilder app);
// }