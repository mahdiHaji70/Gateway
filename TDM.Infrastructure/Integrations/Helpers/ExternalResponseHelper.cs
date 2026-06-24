using System;
using System.Collections.Generic;
using System.Text;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Helpers
{
    public static class ExternalResponseHelper
    {
        public static void EnsureSuccess<T>(GeneralResponse<T> response, string serviceName)
        {
            if (response.Status == ResponseStatuses.Success) return;
            throw new Exception(BuildErrorMessage(serviceName, response));
        }

        public static bool TryEnsureSuccess<T>(GeneralResponse<T> response, string serviceName, out string errorMessage)
        {
            if (response.Status == ResponseStatuses.Success)
            {
                errorMessage = null;
                return true;
            }

            errorMessage = BuildErrorMessage(serviceName, response);
            return false;
        }

        private static string BuildErrorMessage<T>(string serviceName, GeneralResponse<T> response)
        {
            if (!string.IsNullOrWhiteSpace(response.Message))
                return serviceName + Environment.NewLine + response.Message;

            if (response.Errors?.Any() == true)
            {
                var combinedErrors = string.Join($"{Environment.NewLine}• ",
                   response.Errors.Select(x => x.ErrorMessage));
                return serviceName + Environment.NewLine + $"Errors:{Environment.NewLine}• {combinedErrors}";
            }
            return serviceName + Environment.NewLine + "An unknown error occurred.";
        }
    }
}
