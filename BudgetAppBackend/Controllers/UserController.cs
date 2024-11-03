using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Domain.Dtos.UserDto;
using Domain.Dtos.UserDto;
using Domain.Exceptions;
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

        [HttpPost("InitialSetup")]
        public async Task<IActionResult> InitialSetup([FromBody] InitialSetupDto initialSetupDto)
        {
            var id = User.FindFirst("Id")?.Value;
            if (id == null)
            {
                throw new BadRequestException("User does not exist or id is missing in claims");
            }
            await _serviceManager.cardService.CreateCardForUserAsync(id, initialSetupDto.Card, trackChanges: true);
            await _serviceManager.budgetCategoryService.CreateBudgetCategoryForUserAsync(id, initialSetupDto.Category1, trackChanges: true);
            await _serviceManager.budgetCategoryService.CreateBudgetCategoryForUserAsync(id, initialSetupDto.Category2, trackChanges: true);
            await _serviceManager.userService.InitialSetup(id);
            return Ok("Setup Completed");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Users")]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _serviceManager.userService.GetAllUser();
            return Ok(users);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            var userId = User.FindFirst("Id")?.Value;
            await _serviceManager.userService.Logout(userId);
            return Ok();

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
            var id = User.FindFirst("Id")?.Value;
            var username = User.Identity.Name; // This gives the username as it is ClaimTypes.Name

            return Ok(new { Id = id, FirstName = firstName, LastName = lastName, Username = username });
        }

        [Authorize]
        [HttpGet("DetailUserInfo")]
        public async Task<IActionResult> DetailUserInfo()
        {
            var id = User.FindFirst("Id")?.Value;
            var user = await _serviceManager.userService.GetUserDetail(id);

            return Ok(user);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditUserInfo([FromBody] UserDetailDto userDetailDto)
        {
            var id = User.FindFirst("Id")?.Value;
            await _serviceManager.userService.EditUserInfo(userDetailDto, id);
            return NoContent();


        }

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