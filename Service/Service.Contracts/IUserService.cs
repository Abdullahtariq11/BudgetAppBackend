using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Domain.Models;
using BudgetApp.Shared.Dtos.UserDto;
using Microsoft.AspNetCore.Identity;

namespace Service.Service.Contracts
{
    public interface IUserService
    {
        public Task<IdentityResult> RegisterUser(RegisterationDto registerationDto);
        public Task<ICollection<CreatedUserDto>> GetAllUser();
        public Task<bool> Login(LoginDto loginDto);
        public Task<bool> DeleteUser(string userId);
    }
}