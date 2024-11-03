using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Domain.Dtos.UserDto;
using BudgetApp.Domain.Models;
using Domain.Dtos.UserDto;
using Microsoft.AspNetCore.Identity;

namespace Service.Service.Contracts
{
    public interface IUserService
    {
        public Task<string> GenerateJwtToken(User user);
        public Task<string> RegisterUser(RegisterationDto registerationDto);
        public Task<ICollection<CreatedUserDto>> GetAllUser();

        public Task EditUserInfo(UserDetailDto userDetailDto,string userId);
        public Task InitialSetup(string userId);

        public  Task Logout(string userId);

        public Task<UserDetailDto> GetUserDetail(string userId);
        public Task<string> Login(LoginDto loginDto);
        public Task<bool> DeleteUser(string userId);
    }
}