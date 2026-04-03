using WebApplication1.Controller;

namespace WebApplication1.Routes;

public static class HomeRouter
{
    public static RouteGroupBuilder RouteHomeEndpoints(this RouteGroupBuilder router)
    {
        var homeHandle = new HomeHandle();
        router.MapGet("/test", homeHandle.GetHome);
        return router;
    }
}