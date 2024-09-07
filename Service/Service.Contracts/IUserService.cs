using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Shared.Dtos.UserDto;
using Microsoft.AspNetCore.Identity;

namespace Service.Service.Contracts
{
    public interface IUserService
    {
        public Task<IdentityResult> RegisterUser(RegisterationDto registerationDto);
    }
}