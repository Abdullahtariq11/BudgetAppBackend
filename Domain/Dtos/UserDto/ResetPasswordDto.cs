using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Domain.Dtos.UserDto
{
    public class ResetPasswordDto
    {
        public string NewPassword { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
