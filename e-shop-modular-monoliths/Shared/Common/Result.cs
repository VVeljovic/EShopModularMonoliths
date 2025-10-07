namespace Shared.Common;

public class Result<T>
{
    public string Error { get; set; } = default!;

    public bool Success { get; set; } = default!;

    public T Value { get; set; } = default!;

    private Result(string error, bool success, T value)
    {
        Error = error;
        Success = success;
        Value = value;
    }

    public static Result<T> Ok(T value) => new Result<T>(null, true, value);

    public static Result<T> Failure(string error) => new Result<T>(error, false, default(T));
}
