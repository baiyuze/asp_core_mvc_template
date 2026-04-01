namespace WebApplication1.Routes;

public static class Router
{
    public static RouteGroupBuilder RouteStart(this RouteGroupBuilder router)
    {
        router.MapGet("/test",() => "test");
        router.MapGroup("/home").RouteHomeStart();
        router.MapGroup("/group").RouteGroupStart();
        return router;
    }
}