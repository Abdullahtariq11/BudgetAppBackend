using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Dtos.UserDto;
using BudgetApp.Domain.Models;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Service.Service.Contracts;

namespace Service.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<UserService> logger, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<string> GenerateJwtToken(User user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),                // Username
                new Claim(ClaimTypes.NameIdentifier, user.Id),            // UserID
                 new Claim("Id", user.Id),
                new Claim("FirstName", user.FirstName),                   // First Name
                new Claim("LastName", user.LastName),                      // Last Name
                new Claim("SecurityStamp", user.SecurityStamp)
            };


            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JWT:DurationInMinutes"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Login Method for user
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        public async Task<string> Login(LoginDto loginDto)
        {
            _logger.LogInformation("Logging in");
            var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password,
            loginDto.RememberMe, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new BadRequestException("Invalid login attempt");
            }
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            return await GenerateJwtToken(user);

        }

        public async Task Logout(string userId)
        {
            _logger.LogInformation("User Logging out");
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new BadRequestException($"Unable to load user with id {userId}");
            }
            // Update SecurityStamp to invalidate the token
            await _userManager.UpdateSecurityStampAsync(user);
            await _signInManager.SignOutAsync();

        }

        public async Task<UserDetailDto> GetUserDetail(string userId)
        {
            _logger.LogInformation("Getting user details");

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new BadRequestException("Invalid User");
            }
            var userDto = new UserDetailDto(user.FirstName, user.LastName, user.Email,
            user.Email, user.PhoneNumber);

            return userDto;
        }

        public async Task EditUserInfo(UserDetailDto userDetailDto, string userId)
        {
            _logger.LogInformation("Getting user details");

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new BadRequestException("Invalid User");
            }
            user.FirstName = userDetailDto.FirstName;
            user.LastName = userDetailDto.LastName;
            user.Email = userDetailDto.Email;
            user.PhoneNumber = userDetailDto.PhoneNumber;
            // Persist changes to the database
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Failed to update user: {errors}");
            }
            _logger.LogInformation("User  updated successfully");

        }

        public async Task<ICollection<CreatedUserDto>> GetAllUser()
        {
            _logger.LogInformation("Getting All the users");
            var users = await _userManager.Users.AsNoTracking().ToListAsync();
            var userDtos = new List<CreatedUserDto>();
            foreach (var user in users)
            {
                var userDto = new CreatedUserDto(user.FirstName, user.LastName, user.UserName);
                userDtos.Add(userDto);
            }
            return userDtos;
        }

        public async Task<IdentityResult> RegisterUser(RegisterationDto registerationDto)
        {
            _logger.LogInformation("Registering User");
            var user = new User
            {
                FirstName = registerationDto.FirstName,
                LastName = registerationDto.LastName,
                Email = registerationDto.Email,
                PhoneNumber = registerationDto.PhoneNumber,
                UserName = registerationDto.userName
            };
            var result = await _userManager.CreateAsync(user, registerationDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
            }
            return result;
        }

        public async Task InitialSetup(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new BadRequestException($"User with ID {userId} does not exist");
            }

            if (user.SetupComplete)
            {
                throw new BadRequestException("Setup is already complete.");
            }

            user.SetupComplete = true;
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Failed to update user: {errors}");
            }

            _logger.LogInformation("Setup completed successfully for user {UserId}", userId);
        }

        public async Task<bool> DeleteUser(string userId)
        {
            _logger.LogInformation("Deleting User");
            var user = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return false;
            }
            await _userManager.DeleteAsync(user);
            return true;
        }
    }
}