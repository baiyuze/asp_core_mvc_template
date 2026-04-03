namespace WebApplication1.Routes;

public static class GroupEndpoints
{
    public static RouteGroupBuilder RouteGroupEndpoints(this RouteGroupBuilder router)
    {
        router.MapGet("/test", () => "test");
        return router;
    }
}