using CookieStandApi.Models.DTOs;
using CookieStandAPI.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CookieStandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _userService;
        public UsersController(IUser service)
        {
            _userService = service;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Login(LoginDataDto loginDto)
        {
            var user = await _userService.Login(loginDto);

            if (user == null)
            {
                return Unauthorized();
            }
            return user;
        }
    }
}
