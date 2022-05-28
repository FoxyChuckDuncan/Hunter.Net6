using AutoMapper;
using Hunter.API.Contracts;
using Hunter.API.Data;
using Hunter.API.DTOs.Users;
using Microsoft.AspNetCore.Identity;

namespace Hunter.API.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;

        public AuthManager(IMapper mapper, UserManager<ApiUser> userManager)
        {
            this._mapper = mapper;
            this._userManager = userManager;
        }

        public async Task<bool> Login(LoginDto loginDto)
        {
            bool isValidUser = false;

            try
            {
                var user = await _userManager.FindByNameAsync(loginDto.UserName);
                isValidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            }
            catch (Exception)
            {
            }
            return isValidUser;
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
    }
}
