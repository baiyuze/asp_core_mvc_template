using Microsoft.AspNetCore.Diagnostics;

namespace WebApplication1.Middleware;

public class Message
{
   public static async Task  DefineMessage( StatusCodeContext context )
    {
        var response = context.HttpContext.Response;
        if (response.StatusCode == StatusCodes.Status401Unauthorized)
        {
            await response.WriteAsJsonAsync(new { code = 401, message = "Unauthorized" });
        }
    }
}