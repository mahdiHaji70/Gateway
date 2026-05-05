namespace ExternalIntegration.Service.Application.Shared
{
    public class Response<T>
    {

        public ResponseStatuses Status { get; set; }
        public string? Message { get; set; }
        public List<ErrorModel>? Errors { get; set; }
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

        public static Response<T> Error(string message = "Operation error", List<ErrorModel>? errors = null)
        {
            if (errors != null && errors.Any())
                message = string.Join(Environment.NewLine, errors.Select(s => s.ErrorMessage).ToList());

            return new Response<T>()
            {
                Message = message,
                Status = ResponseStatuses.Error,
                Errors = errors!
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
