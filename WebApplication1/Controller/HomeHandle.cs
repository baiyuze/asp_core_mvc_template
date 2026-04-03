using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controller;

[ApiController]
public class HomeHandle
{
    public string GetHome()
    {
        return "Home";
    }
}