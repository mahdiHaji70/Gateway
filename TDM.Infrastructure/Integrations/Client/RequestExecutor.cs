using Azure;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TDM.Infrastructure.Integrations.Auth;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Client
{
    public class RequestExecutor : IRequestExecutor
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;
        private readonly string _baseAddress;


        public RequestExecutor(HttpClient httpClient,
            IConfiguration configuration,
            AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
            _baseAddress = configuration["ServiceProviderConfig:Gateway:BaseAddress"]!;
        }

        public async Task<GeneralResponse<T>> PostAsync<T>(string controllerName, string actionName, object requestData, CancellationToken cancellationToken = default)
        {
            var json = JsonConvert.SerializeObject(requestData);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, _baseAddress + $"/{controllerName}/{actionName}") { Content = httpContent };

            var token = await _authService.GetAccessTokenAsync("0410373702", "Aa@12345", cancellationToken);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to retrieve external service token " + response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync(cancellationToken);

            var result = JsonConvert.DeserializeObject<GeneralResponse<T>>(responseString);

            return result!;

        }

        public async Task<GeneralResponse<T>> GetAsync<T>(string controllerName, string actionName, object? queryParams = null, CancellationToken cancellationToken = default)
        {
            var url = $"{_baseAddress}/{controllerName}/{actionName}";

            if (queryParams != null)
            {
                var query = string.Join("&",
                    queryParams.GetType()
                        .GetProperties()
                        .Select(p =>
                        {
                            var value = p.GetValue(queryParams);
                            return $"{Uri.EscapeDataString(p.Name)}={Uri.EscapeDataString(value?.ToString() ?? "")}";
                        }));

                url += $"?{query}";
            }

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var token = await _authService.GetAccessTokenAsync("0410373702", "Aa@12345", cancellationToken);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to call external service " + response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync(cancellationToken);

            var result = JsonConvert.DeserializeObject<GeneralResponse<T>>(responseString);

            return result!;
        }

    }
}
