namespace WebApplication1.Routes;

public static class MapRoutes
{
    public static RouteGroupBuilder MapRouteGroups(this RouteGroupBuilder router)
    {
        router.MapGet("/test",() => "test");
        router.MapGroup("/home").RouteHomeEndpoints();
        router.MapGroup("/group").RouteGroupEndpoints();
        return router;
    }
}