using Microsoft.AspNetCore.Mvc;
using WebApplication1.Infrastructure;

namespace WebApplication1.Modules.HomeModule;


public class HomeHandle: IScopedHandle
{
    public string GetHome(HttpContext context)
    {
        return "Home";
    }
}