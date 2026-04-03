using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// --- 核心：一键扫描并注册 ---
// app.MapAllEndpoints(); 
EndpointScanner.MapAllEndpoints(app);
app.Run();

// 1. 定义模块化接口
public interface IEndpointModule
{
    void Map(IEndpointRouteBuilder app);
}
//
// // 2. 编写具体的业务模块 A
// public class HomeModule : IEndpointModule
// {
//     public void Map(IEndpointRouteBuilder app)
//     {
//         app.MapGet("/", () => "Welcome to Home Module!");
//     }
// }
//
// // 3. 编写具体的业务模块 B (哪怕在不同类里也能被扫到)
// public class VoiceModule : IEndpointModule
// {
//     public void Map(IEndpointRouteBuilder app)
//     {
//         app.MapGet("/voice", () => "Voice Service is Active!");
//     }
// }


public static class EndpointScanner
{
    public static void MapAllEndpoints(this IEndpointRouteBuilder app)
    {
        // 先获取这个函数里有哪些实现类注册进来，筛选自定义的实现类型一致，最后过滤类，实例化这个类。
        var assembly = Assembly.GetExecutingAssembly();

        var modules = assembly.GetTypes();

        List<Type> moduleTypes = new List<Type>();
        foreach (var moduleType in modules)
        {
            // var type = module.GetInterfaces();
            if (typeof(IEndpointModule).IsAssignableFrom(moduleType) && !moduleType.IsAbstract && !moduleType.IsInterface)
            {
                moduleTypes.Add(moduleType);
            }
        }

        foreach (var type in moduleTypes)
        {
            // 实例化类
            var module = Activator.CreateInstance(type) as IEndpointModule;
            module?.Map(app);
        }
    }
}
//
// // 4. 实现扫描器扩展
// public static class EndpointScanner
// {
//     public static void MapAllEndpoints(this IEndpointRouteBuilder app)
//     {
//         // 获取当前正在运行的程序集
//         var assembly = Assembly.GetExecutingAssembly();
//
//         // 扫描原理：
//         // t.IsInterface = 排除接口本身
//         // t.IsAbstract = 排除抽象类
//         // typeof(IEndpointModule).IsAssignableFrom(t) = 确认类实现了该接口
//         var moduleTypes = assembly.GetTypes()
//             .Where(t => typeof(IEndpointModule).IsAssignableFrom(t) 
//                         && !t.IsInterface 
//                         && !t.IsAbstract);
//
//         foreach (var type in moduleTypes)
//         {
//             // 实例化类
//             var module = Activator.CreateInstance(type) as IEndpointModule;
//             
//             // 执行映射逻辑
//             module?.Map(app);
//             
//             Console.WriteLine($"[Scanner] 已自动挂载模块: {type.Name}");
//         }
//     }
// }