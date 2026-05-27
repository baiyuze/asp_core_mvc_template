using Microsoft.AspNetCore.Diagnostics;

namespace WebApplication1.Middleware;
/// <summary>
/// 统一处理状态码入口
/// </summary>
public class Message
{
   public static async Task DefineMessage(StatusCodeContext context)
    {
        var response = context.HttpContext.Response;
        if (response.StatusCode == StatusCodes.Status401Unauthorized)
        {
            response.ContentType = "application/json";
            await response.WriteAsJsonAsync(new { code = 401, message = "Unauthorized" });
        }
        
        if (response.StatusCode == StatusCodes.Status404NotFound)
        {
            response.ContentType = "application/json";
            await response.WriteAsJsonAsync(new { code = 404, message = "NOT FOUND" }); 
        }
    }
}
