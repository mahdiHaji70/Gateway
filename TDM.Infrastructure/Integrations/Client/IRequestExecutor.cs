
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Client
{
    public interface IRequestExecutor
    {
        Task<GeneralResponse<T>> PostAsync<T>(string controllerName, string actionName, object requestData, CancellationToken cancellationToken = default);

        Task<GeneralResponse<T>> GetAsync<T>(string controllerName, string actionName, object? queryParams = null, CancellationToken cancellationToken = default);
    }
}
