namespace WebApplication1.Routes;

public static class Group
{
    public static RouteGroupBuilder RouteGroupStart(this RouteGroupBuilder router)
    {
        router.MapGet("/test", () => "test");
        return router;
    }
}