using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.Dtos.UserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Service.Contracts;

namespace Service.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;  
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;
        public UserService(UserManager<User> userManager,SignInManager<User> signInManager,ILogger<UserService>logger)
        {
            _userManager=userManager;
            _signInManager=signInManager;
            _logger=logger;
        }

        public async Task<bool> Login(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password,
            loginDto.RememberMe,lockoutOnFailure:false);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;

        }

        public async Task<ICollection<CreatedUserDto>> GetAllUser()
        {
            var users=await _userManager.Users.AsNoTracking().ToListAsync();
            var userDtos=new List<CreatedUserDto>();
            foreach (var user in users)
            {
                var userDto=new CreatedUserDto(user.FirstName,user.LastName,user.UserName);
                userDtos.Add(userDto);
            }
            return userDtos;
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

        public async Task<bool> DeleteUser(string userId)
        {
            var user = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(u=>u.Id == userId);
            if (user == null)
            {
                return false;
            }
            await _userManager.DeleteAsync(user);
            return true;
        }
    }
}