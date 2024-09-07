using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Domain.Models
{
    public class BudgetCategory
    {
        [Column("BudgetCategoryId")]
        public Guid Id { get; set; }= Guid.NewGuid();
        [Required(ErrorMessage = "Amount value is required")]
        public decimal AllocatedAmount { get; set; }
        public decimal RemainingAmount { get; set; }= decimal.Zero;
        public DateTime LastUpdated { get; set; }

        [Required(ErrorMessage = "Category Name value is required")]
        public string? CategoryName { get; set; }


        [Required(ErrorMessage = "userId is required")]
        public string? UserID { get; set; }
        public User? User { get; set; }

    }
}
