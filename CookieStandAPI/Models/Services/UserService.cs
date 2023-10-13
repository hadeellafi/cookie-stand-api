using CookieStandApi.Models.DTOs;
using CookieStandApi.Models.Entities;
using CookieStandAPI.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CookieStandAPI.Models.Services
{
    public class UserService : IUser
    {
        private readonly UserManager<AuthUser> _userManager;
        private JwtTokenService tokenService;

        public UserService(UserManager<AuthUser> userManager, JwtTokenService tokenService)
        {
            _userManager = userManager;
            this.tokenService = tokenService;

        }

        public async Task<UserDto> Login(LoginDataDto loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.Username);
            bool checkPassword = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (checkPassword)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(5))
                };

            }
            return null;
        }
    }
}
