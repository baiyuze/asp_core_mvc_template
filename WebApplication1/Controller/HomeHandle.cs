using Microsoft.AspNetCore.Mvc;
using WebApplication1.Infrastructure;

namespace WebApplication1.Controller;

[ApiController]
public class HomeHandle: IScopedHandle
{
    public string GetHome()
    {
        return "Home";
    }
}