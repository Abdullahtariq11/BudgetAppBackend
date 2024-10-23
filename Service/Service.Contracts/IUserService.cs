using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Domain.Dtos.UserDto;
using BudgetApp.Domain.Models;

using Microsoft.AspNetCore.Identity;

namespace Service.Service.Contracts
{
    public interface IUserService
    {
        public Task<string> GenerateJwtToken(User user);
        public Task<IdentityResult> RegisterUser(RegisterationDto registerationDto);
        public Task<ICollection<CreatedUserDto>> GetAllUser();
        public Task<string> Login(LoginDto loginDto);
        public Task<bool> DeleteUser(string userId);
    }
}