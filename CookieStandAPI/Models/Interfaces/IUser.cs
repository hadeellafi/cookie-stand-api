using CookieStandApi.Models.DTOs;

namespace CookieStandAPI.Models.Interfaces
{
    public interface IUser
    {
        Task<UserDto> Login(LoginDataDto loginDTO);

    }
}
