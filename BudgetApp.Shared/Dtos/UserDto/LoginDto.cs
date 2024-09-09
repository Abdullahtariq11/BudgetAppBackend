using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Shared.Dtos.UserDto
{
    public record LoginDto(string Username,string Password,bool RememberMe);

}