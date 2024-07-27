namespace MediatorCQRS.Helpers.DTOS
{
    public interface IResult
    {
        string[]? Errors { get; }
        bool IsSuccess { get; }
        string Messages { get; }
    }
    public interface IResult<T> : IResult
    {
        T? Data { get; }
        Exception? Exception { get; }
        int TotalCountData { get; }
    }
}