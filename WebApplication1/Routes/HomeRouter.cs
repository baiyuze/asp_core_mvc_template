namespace WebApplication1.Routes;

public static class HomeRouter
{
    public static RouteGroupBuilder RouteHomeStart(this RouteGroupBuilder router)
    {
        router.MapGet("/test", () => "home");
        return router;
    }
}