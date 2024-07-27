using MediatorCQRS.Helpers.Constants;

namespace MediatorCQRS.Helpers.DTOS
{
    public class ResultDtoWithPagination<T> : Result<T>
    {
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Dictionary<string, string> MessagesDir { get; set; }
        public decimal TotalPrice { get; set; }
        public ResultDtoWithPagination()
        {
            MessagesDir = new Dictionary<string, string>();
        }
        public ResultDtoWithPagination<T> Success(string message, T? data = default)
        {
            IsSuccess = true;
            Messages = message;
            Data = data;

            return this;
        }
        public ResultDtoWithPagination<T> Success(T data) => Success(MessagesEn.SuccessMessage, data);
    }
}
