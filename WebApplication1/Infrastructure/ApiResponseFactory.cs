

namespace Infrastructure;

public class ApiResponse<T>
{
  public int Code { get; set; }
  public string Message { get; set; } = "";
  public T? Data { get; set; }

}

public class ApiResponseFactory
{
  public ApiResponse<T> Success<T>(T data, string message = "success")
  {
    return new ApiResponse<T>
    {
      Code = 200,
      Message = message,
      Data = data
    };
  }

  public ApiResponse<T?> Fail<T>(int code, string message)
  {
    return new ApiResponse<T?>
    {
      Code = code,
      Message = message,
      Data = default
    };
  }
}
