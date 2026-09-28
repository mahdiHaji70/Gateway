namespace ExternalIntegration.Service.Application.Shared
{
    public class Response<T>
    {

        public ResponseStatuses Status { get; set; }
        public string? Message { get; set; }
        public Dictionary<string, string[]>? Errors { get; set; }
        public T? Data { get; set; }

        public static Response<T> Success(T? data = default, string successMessage = "Operation successfully done")
        {
            return new Response<T>()
            {
                Data = data!,
                Message = successMessage,
                Status = ResponseStatuses.Success
            };
        }

        public static Response<T> Error(string message = "Operation error", Dictionary<string, string[]>? errors = null)
        {
            return new Response<T>()
            {
                Message = errors != null && errors.Any()
                    ? string.Join(Environment.NewLine, errors.Values.SelectMany(x => x))
                    : message,
                Status = ResponseStatuses.Error,
                Errors = errors
            };
        }

        public static Response<T> Warning(string message)
        {
            return new Response<T>()
            {
                Message = message,
                Status = ResponseStatuses.Warning,
            };
        }

        public static Response<T> Info(string message)
        {
            return new Response<T>()
            {
                Message = message,
                Status = ResponseStatuses.Information,
            };
        }

    }
}
