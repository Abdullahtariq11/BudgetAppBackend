using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Domain.Dtos.UserDto
{
    public record RegisterationDto(string FirstName,string LastName
    ,string userName,string Password,string Email,string PhoneNumber,string Role);

}