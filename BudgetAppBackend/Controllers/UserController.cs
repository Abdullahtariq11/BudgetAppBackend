using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Shared.Dtos.UserDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAppBackend.Controllers
{
    [ApiController]
    [Route("api/Users")]


    public class UserController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }



        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterationDto registerationDto)
        {

            var result = await _serviceManager.userService.RegisterUser(registerationDto);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Users")]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _serviceManager.userService.GetAllUser();
            return Ok(users);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _serviceManager.userService.Login(loginDto);
            return Ok(new { Token = token });
        }
        [Authorize]
        [HttpGet("UserInfo")]
        public IActionResult GetUserInfo()
        {
            var firstName = User.FindFirst("FirstName")?.Value;
            var lastName = User.FindFirst("LastName")?.Value;
            var username = User.Identity.Name; // This gives the username as it is ClaimTypes.Name

            return Ok(new { FirstName = firstName, LastName = lastName, Username = username });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{userId=string}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string userId)
        {
            var result = await _serviceManager.userService.DeleteUser(userId);
            if (result == false)
            {
                return BadRequest("user not deleted");
            }
            return Ok($"{userId} Deleted");
        }


    }
}