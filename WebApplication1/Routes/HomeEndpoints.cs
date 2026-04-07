using WebApplication1.Controller;

namespace WebApplication1.Routes;

public static class HomeRouter
{
    public static RouteGroupBuilder RouteHomeEndpoints(this RouteGroupBuilder router)
    {

        router.MapGet("/test", (HomeHandle homeHandle) => homeHandle.GetHome());
        return router;
    }
}