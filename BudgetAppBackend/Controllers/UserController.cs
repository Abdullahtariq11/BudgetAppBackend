using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Application.Service.Contracts;
using BudgetApp.Shared.Dtos.UserDto;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public UserController(IServiceManager serviceManager)
        {
            _serviceManager=serviceManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody]RegisterationDto registerationDto)
        {

            var result = await _serviceManager.userService.RegisterUser(registerationDto);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors){
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }
    }
}