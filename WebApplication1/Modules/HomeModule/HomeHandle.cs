using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Infrastructure;

namespace WebApplication1.Modules.HomeModule;


public class HomeHandle : IScopedHandle
{
    private ApiResponseFactory apiResponse;

    public HomeHandle(ApiResponseFactory _apiResponse)
    {
        apiResponse = _apiResponse;
    }
    public IResult GetHome(HttpContext context)
    {
        var home = "Home  ";
        home = home.TrimEnd();

        string data = home.ToUpper() + "-";
        double a = 5;
        double b = 4;
        double c = 2;
        double d = (a + b) / c;
        Console.WriteLine(d);
        double max = double.MaxValue;
        double min = double.MinValue;

        Console.WriteLine($"The range of double is {min} to {max}");
        decimal min1 = decimal.MinValue;
        decimal max1 = decimal.MaxValue;
        decimal f = 3.0M;
        Console.WriteLine($"The range of the decimal type is {min1} to {max1}--- {f}");

        // 元组
        var pt = (x1: 1, y: 2);
        Console.WriteLine($"元组 {pt}");

        Point point = new Point(1, 2);

        Point point1 = new Point(1, 2);

        Point point2 = point1 with { X = 3 };

        // record只对比值，不对比引用类型。
        Console.WriteLine($"记录类型: {point}, {point == point1} point2:{point2}");
        var list = new List<string> { "1.2", "33" };

        foreach (var item in list)
        {
            Console.WriteLine($"{item}==");
        }
        var list2 = list.Select(item =>
        {
            Console.WriteLine($"=11==={item}");
            return item + 11;
        }).ToList();
        Console.WriteLine($"{list2}==,${list}");

        return Results.Ok(apiResponse.Success(data));
    }

    public record class Point
    {
        public int X = 0;
        public int Y = 0;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

}
