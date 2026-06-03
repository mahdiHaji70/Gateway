using Azure;
using Microsoft.Extensions.Configuration;
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

        public async Task<GeneralResponse<T>> PostAsync<T>(string controllerName, string actionName,object requestData, CancellationToken cancellationToken = default)
        {
            var json = JsonSerializer.Serialize(requestData);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, _baseAddress + $"/{controllerName}/{actionName}") { Content = httpContent };

            var token = await _authService.GetAccessTokenAsync("0410373702", "Aa@12345", cancellationToken);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to retrieve external service token " + response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync(cancellationToken);

            var result = JsonSerializer.Deserialize<GeneralResponse<T>>(responseString);

            return result!;

        }
    }
}
