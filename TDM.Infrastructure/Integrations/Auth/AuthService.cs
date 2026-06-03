using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;

namespace TDM.Infrastructure.Integrations.Auth
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;

        public AuthService(HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseAddress = configuration["ServiceProviderConfig:Gateway:AuthBaseAddress"]!;

        }

        public async Task<string> GetAccessTokenAsync(string nationalId, string password, CancellationToken cancellationToken)
        {
            var request = new {
                nationalId = nationalId,
                password = password
            };

            var json = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_baseAddress + "/login", httpContent, cancellationToken);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to retrieve external service token " + response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync(cancellationToken);
            var result = JsonSerializer.Deserialize<Token>(responseString);

            return result!.AccessToken!;
        }
    }
}
