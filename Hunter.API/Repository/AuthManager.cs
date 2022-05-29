using AutoMapper;
using Hunter.API.Contracts;
using Hunter.API.Data;
using Hunter.API.DTOs.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hunter.API.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthManager(IMapper mapper, UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            bool isValidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (user is null || isValidUser is false) return null;

            var token = GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token.Result,
                UserId = user.Id
            };
        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto)
        {
            var user = _mapper.Map<ApiUser>(userDto);
            user.UserName = userDto.UserName;

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                IEnumerable<string> selectedRoles = new[] { "USER", "VISITOR" };
                await _userManager.AddToRolesAsync(user, selectedRoles);
            }
            
            return result.Errors;
        }

        private async Task<string> GenerateToken(ApiUser user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

            var credentials = new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            //  new Claim("LicenseType", "valuegoeshere")
            }
            .Union(userClaims).Union(roleClaims);

            double hours = Convert.ToDouble(_configuration["JwtSettings:DurationInHours"]);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Key"],
                audience: _configuration["JwtSettings:Key"],
                claims: claims,
                expires: DateTime.Now.AddHours(hours),
                signingCredentials: credentials
                ); ;

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
