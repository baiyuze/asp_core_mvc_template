using System.Reflection;
using Infrastructure;

namespace WebApplication1.Infrastructure;

public static class DependencyInjectionExtensions
{
    // 自动发现
    // 读取类型，并且过滤，并发现
    // 判断是否属于这个类型
    // 添加到scope由框架进行实例化注册
    // 自动di
    /// <summary>
    /// 自动扫描注册Handle和service
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration?  configuration = null)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();
        var typeHandleModule = types.Where(type => typeof(IScopedService).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract);
        foreach (var type in typeHandleModule)
        {
            services.AddScoped(type);
            Console.WriteLine($"[Build] Registered Handle: {type.Name}");
        }
        
        var typeServicesModule = types.Where(type => typeof(IScopedHandle).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract);
        foreach (var type in typeServicesModule)
        {
            services.AddScoped(type);
            Console.WriteLine($"[Build] Registered Service: {type.Name}");
        }

        return services;
    }
    

}

