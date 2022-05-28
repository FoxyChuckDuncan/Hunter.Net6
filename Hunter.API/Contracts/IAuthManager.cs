using Hunter.API.DTOs.Users;
using Microsoft.AspNetCore.Identity;

namespace Hunter.API.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        Task<bool> Login(LoginDto loginDto);
    }
}
