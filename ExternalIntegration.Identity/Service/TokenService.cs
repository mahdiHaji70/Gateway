using IntegratedIdentity.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace IntegratedIdentity.Service
{
    public class TokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public (string Token, DateTime ExpiresAt) GenerateAccessToken(User user)
        {
            var jwtSettings = _config.GetSection("Jwt");
            var lifetimeMinutes = jwtSettings.GetValue<int>("AccessTokenLifetimeMinutes", 480);
            var expiresAt = DateTime.UtcNow.AddMinutes(lifetimeMinutes);

            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
            new Claim("firstName", user.Name ?? ""),
            new Claim("nationalId", user.NationalId?? ""),            
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["Key"]!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: expiresAt,
                signingCredentials: creds);

            return (new JwtSecurityTokenHandler().WriteToken(token), expiresAt);
        }

        public (string Token, DateTime ExpiresAt) GenerateRefreshToken()
        {
            var lifetimeDays = _config.GetSection("Jwt").GetValue<int>("RefreshTokenLifetimeDays", 30);
            var bytes = RandomNumberGenerator.GetBytes(64);
            return (Convert.ToBase64String(bytes), DateTime.UtcNow.AddDays(lifetimeDays));
        }

        public static string HashRefreshToken(string refreshToken)
        {
            var hash = SHA256.HashData(Encoding.UTF8.GetBytes(refreshToken));
            return Convert.ToHexString(hash);
        }
    }
}
