using Azure.Core;
using IntegratedIdentity.Domain;
using IntegratedIdentity.Dtos;
using IntegratedIdentity.Infrastructure.Data;
using IntegratedIdentity.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntegratedIdentity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;
        private readonly IdentityDbContext _identityDbContext;

        public AuthController(
            UserManager<User> userManager,
            TokenService tokenService,
            IdentityDbContext identityDbContext)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _identityDbContext = identityDbContext;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto model)
        {
            var user = new User
            {
                Name = model.Name,
                NationalId = model.NationalId,                
                UserName = model.Name,
                Email = model.NationalId + "@test.com"
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("User registered successfully.");
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            //var user = await _userManager.FindByEmailAsync(model.NationalId);
            var user = await _identityDbContext.User.Where(x => x.NationalId == model.NationalId).FirstOrDefaultAsync();

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized("username or password incorrect");


            if (user == null)
                return Unauthorized("Invalid credentials");

            if (!await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized("Invalid credentials");

            var accessToken = _tokenService.GenerateAccessToken(user);

            //to do
            var finalResult = new {
                accessToken = accessToken,
                refreshToken = string.Empty,
                time = DateTimeOffset.UtcNow
            };

            return Ok(finalResult);
        }

        [HttpGet("get_all_users")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _identityDbContext.User.ToListAsync();

            var mappedUsers = users.Select(x => new UserDto{
                Id = x.Id,
                Name = x.Name,
                NationalId = x.NationalId,
            });

            return Ok(new
            {
                mappedUsers
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Login(Guid id)
        {
            //var user = await _userManager.FindByEmailAsync(model.NationalId);
            var user = await _identityDbContext.User.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (user is null)
                return Unauthorized("user not found");

            var result = _userManager.DeleteAsync(user);

            return Ok(new
            {
                result
            });
        }
    }
}
