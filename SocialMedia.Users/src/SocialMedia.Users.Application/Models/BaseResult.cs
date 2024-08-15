namespace SocialMedia.Users.Application.Models;

public class BaseResult
{
    public bool Success { get; private set; }
    public string Message { get; private set; }

    public BaseResult(bool success = true, string message = "")
    {
        Success = success;
        Message = message;
    }
}

public class BaseResult<T> : BaseResult
{
    public T Data { get; private set; }

    public BaseResult(T data, bool success = true, string message = ""): base(success, message)
    {
        Data = data;
    }
}
