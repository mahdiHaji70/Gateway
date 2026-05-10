using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Infrastructure.Encryption;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TOS.Services.Gateway.Infrastructure.Integrations.PMO.Requests;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Auth
{
    public class PmoAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _userName;
        private readonly string _password;
        private readonly string _baseAddress;
        private const string CacheKeyPrefix = "ExternalServiceToken_";
        private readonly IMemoryCache _cache;
        private readonly ITerminalRepository _terminalRepository;
        private readonly AesEncryption _aesEncryption;
        
        //private readonly ILogger<ExternalAuthService> _logger;        

        public PmoAuthService(
            HttpClient httpClient,
            IConfiguration configuration,
            IMemoryCache cache,
            ITerminalRepository terminalRepository,
            AesEncryption aesEncryption//,
            //ILogger<ExternalAuthService> logger
            )
        {
            _httpClient = httpClient;
            _userName = configuration["ServiceProviderConfig:PMO:Username"]!;
            _password = configuration["ServiceProviderConfig:PMO:Password"]!;
            _baseAddress = configuration["ServiceProviderConfig:PMO:BaseAddress"]!;
            _cache = cache;
            _terminalRepository = terminalRepository;  
            _aesEncryption = aesEncryption;            
            //_logger = logger;
        }

        public async Task<string> GetTokenAsync(string terminalCode, CancellationToken cancellationToken)
        {

            if (string.IsNullOrWhiteSpace(terminalCode))
                throw new InvalidOperationException("terminal code is null or empty!");

            var terminal = await _terminalRepository.GetByCodeAsync(terminalCode);
            if (terminal is null)
                throw new InvalidOperationException($"No terminal found in database for terminalCode: {terminalCode}");

            var cacheKey = CacheKeyPrefix + terminal.PortCode;
            if (_cache.TryGetValue(cacheKey, out string? token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                var exp = jsonToken?.Claims.FirstOrDefault(c => c.Type == "exp")?.Value;

                var unixDateTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(exp!)).DateTime;

                if (unixDateTime >= DateTime.UtcNow)
                    return token!;
            }

            var (accessToken, expireIn) = await GetAccessTokenAsync(terminal.PortCode, terminal.Password, terminal.UserName, cancellationToken);
            //var (accessToken, expireIn) = await GetAccessTokenAsync("IRBIK", "golF@gency5o86", "1950866270", cancellationToken);

            if (string.IsNullOrWhiteSpace(accessToken))
                throw new InvalidOperationException("Received empty access token from AuthService.");

            _cache.Set(cacheKey, accessToken, expireIn);

            return accessToken;
        }

        public async Task<(string accessToken, TimeSpan expireIn)> GetAccessTokenAsync(string portCode, string password, string userName, CancellationToken cancellationToken)
        {            
            var request = new PmoRequestBuilder()
                    .WithCredential(_userName, _password)
                    .WithService("ipas-AccountToken")
                    .WithParameters(new List<Parameter>
                    {
                     new Parameter {ParameterName = "username",ParameterValue = userName  },
                     new Parameter {ParameterName = "password",ParameterValue = password },
                     new Parameter {ParameterName = "portCode",ParameterValue = portCode  },
                    })
                    .Build();

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync(_baseAddress, httpContent, cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to retrieve external service token " + response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync(cancellationToken);

            var result = JsonConvert.DeserializeObject<PmoGeneralResponseDto>(responseString);
            var tokenResponse = JsonConvert.DeserializeObject<PmoTokenResponseDto>(result!.ResponseText!);

            return (tokenResponse!.Token!, TimeSpan.FromMinutes(50));
        }
    }
}
