using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.Dtos.UserDto;
using Microsoft.AspNetCore.Identity;
using Service.Service.Contracts;

namespace Service.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;  
        private readonly SignInManager<User> _signInManager;  
        public UserService(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _userManager=userManager;
            _signInManager=signInManager;
        }
        public async Task<IdentityResult> RegisterUser(RegisterationDto registerationDto)
        {
            var user=new User
            {
                FirstName=registerationDto.FirstName,
                LastName=registerationDto.LastName,
                Email=registerationDto.Email,
                PhoneNumber=registerationDto.PhoneNumber,
                UserName=registerationDto.userName        
            };
            var result= await _userManager.CreateAsync(user,registerationDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, registerationDto.Role);
            }
            return result;
        }
    }
}