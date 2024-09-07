using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Domain.Models
{
    public class User:IdentityUser
    {
        [Required(ErrorMessage ="This field is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string? LastName { get; set; }

        ///Navigation Properties

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<BudgetCategory> BudgetCategories { get; set; } = new List<BudgetCategory>();
        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}
