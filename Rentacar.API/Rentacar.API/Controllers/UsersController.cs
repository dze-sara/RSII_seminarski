using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentacar.Dto;
using Rentacar.Dto.Request;
using Rentacar.Resources.Exceptions;
using Rentacar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto userRequest)
        {
            try
            {
                UserDto registeredUser = await _userService.RegisterUser(userRequest);
                return Ok(registeredUser);
            }
            catch(ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginRequestDto loginRequestDto)
        {
            try
            {
                UserDto loggedUser = await _userService.LoginUser(loginRequestDto);
                return Ok(loggedUser);
            }
            catch (UserNotFoundException)
            {
                return null;
            }
            
        }

        [Authorize]
        [HttpGet("filter")]
        public async Task<IActionResult> FilterUsers([FromQuery] FilterUsersDto filterUsersDto)
        {
            List<BaseUserDto> filteredUsers = await _userService.FilterUsers(filterUsersDto);
            return Ok(filteredUsers);
        }

        [Authorize]
        [HttpPost("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto userRequest)
        {
            UserDto registeredUser = await _userService.UpdateUser(userRequest);
            return Ok(registeredUser);
        }
    }
}
