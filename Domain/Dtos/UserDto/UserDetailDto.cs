using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Domain.Dtos.UserDto
{
    public record UserDetailDto(string FirstName,string LastName
    ,string userName,string Email,string PhoneNumber);

}