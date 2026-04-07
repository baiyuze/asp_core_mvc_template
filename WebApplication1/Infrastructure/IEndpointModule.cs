namespace Infrastructure;

public interface IEndpointModule
{
    void Map(IEndpointRouteBuilder app);
}