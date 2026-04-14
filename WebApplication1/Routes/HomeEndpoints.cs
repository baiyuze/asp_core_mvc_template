using WebApplication1.Modules.HomeModule;

namespace WebApplication1.Routes;

public static class HomeRouter
{
    public static RouteGroupBuilder RouteHomeEndpoints(this RouteGroupBuilder router)
    {

        router.MapGet("/test", (HomeHandle homeHandle, HttpContext context) => homeHandle.GetHome(context)).RequireAuthorization();
        return router;
    }
}