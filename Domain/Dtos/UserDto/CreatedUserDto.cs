using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Domain.Dtos.UserDto
{
    public record CreatedUserDto(string FirstName,string LastName,string Username);

}