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
        public async Task<IActionResult> Register(UserDto model)
        {
            var user = new User
            {
                Name = model.Name,
                NationalId = model.NationalId,
                TerminalCode = model.TerminalCode,
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

            return Ok(new
            {
                accessToken                
            });
        }
    }
}
