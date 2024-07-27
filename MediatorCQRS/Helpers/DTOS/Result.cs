using MediatorCQRS.Helpers.Constants;

namespace MediatorCQRS.Helpers.DTOS
{
    public class Result : IResult
    {
        protected Result() { }
        protected Result(bool isSuccess, string message, string[]? errors = null)
        {
            IsSuccess = isSuccess;
            Messages = message;
            Errors = errors;
        }
        public static Result Success(string message) => new Result(true, message);
        public static Result Success() => new Result(true, MessagesEn.SuccessMessage); // Modified to prevent recursive call
        public static Result Failure(string message, string[]? errors) => new Result(false, message, errors);
        public static Result Failure(string message) => new Result(false, message); // Modified to prevent recursive call
        public static Result Failure(string[]? errors) => new Result(false, MessagesEn.FailureMessage, errors!);
        public static Result Failure() => new Result(false, MessagesEn.FailureMessage); // Modified to prevent recursive call

        #region Properties
        public string Messages { get; protected set; } = string.Empty;
        public bool IsSuccess { get; protected set; }
        public string[]? Errors { get; protected set; }
        #endregion
    }

    public class Result<T> : Result, IResult<T>
    {
        protected Result() { }
        protected Result(bool isSuccess, string message, T? data = default, string[]? errors = null, Exception? exception = null)
            : base(isSuccess, message, errors)
        {
            Data = data;
            Exception = exception;
        }

        public new static Result<T> Failure(string message, T? data = default, string[]? errors = null, Exception? exception = null)
            => new Result<T>(false, message, data, errors, exception);
        public static Result<T> Failure(string message, T data)
             => new Result<T>(false, message, data);

        public static Result<T> Failure(T data)
            => new Result<T>(false, MessagesEn.FailureMessage, data);
        public static Result<T> Failure(string[]? errors = null, Exception? exception = null)
            => new Result<T>(false, MessagesEn.FailureMessage, default, errors, exception);
        public static Result<T> Failure(Exception exception)
            => new Result<T>(false, exception.Message, default, new[] { exception?.Message! }, exception);
        public static Result<T> Success(string message, T? data = default, int totalCountData = 0)
            => new Result<T>(true, message, data)
            {
                TotalCountData = totalCountData
            };
        public static Result<T> Success(T? data, int totalCountData = 0)
            => new Result<T>(true, MessagesEn.SuccessMessage, data)
            {
                TotalCountData = totalCountData
            };

        #region Properties
        public T? Data { get; protected set; }
        public Exception? Exception { get; protected set; }
        public int TotalCountData { get; private set; }
        #endregion
    }
}
