namespace TDM.API.Common.Models
{
    public class ApiResponse
    {
        public bool IsSuccessful { get; set; }

        public string? Message { get; set; }

        public object? Data { get; set; }

        public object? Errors { get; set; }

        public ApiResponse(bool isSuccessful, object? data = null, string? message = null, object? errors = null)
        {
            IsSuccessful = isSuccessful;
            Data = data;
            Message = message;
            Errors = errors;
        }

        public static ApiResponse Success(object? data = null, string? message = null)
            => new(true, data, message);

        public static ApiResponse Fail(string message, object? errors = null)
            => new(false, null, message, errors);
    }
}
