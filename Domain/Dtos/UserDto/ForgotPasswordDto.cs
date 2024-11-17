using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Domain.Dtos.UserDto
{
    public class ForgotPasswordDto
    {
        public string Email { get; set; }
        public string ClientUrl { get; set; }
    }
}
