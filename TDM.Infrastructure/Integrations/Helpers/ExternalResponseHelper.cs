using System;
using System.Collections.Generic;
using System.Text;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Helpers
{
    public static class ExternalResponseHelper
    {
        public static void EnsureSuccess<T>(this GeneralResponse<T> response, string serviceName)
        {
            if (response.Status == ResponseStatuses.Success)
                return;

            if (!string.IsNullOrWhiteSpace(response.Message))
            {
                throw new Exception(serviceName + Environment.NewLine + response.Message);
            }

            if (response.Errors?.Any() == true)
            {
                var combinedErrors = string.Join($"{Environment.NewLine}• ",
                    response.Errors.Select(x => x.ErrorMessage));

                throw new Exception(serviceName + Environment.NewLine + $"Errors:{Environment.NewLine}• {combinedErrors}");
            }

            throw new Exception(serviceName + Environment.NewLine + "An unknown error occurred.");
        }
    }
}
