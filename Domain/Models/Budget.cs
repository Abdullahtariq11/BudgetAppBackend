using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Domain.Models
{
    public class Budget
    {
        [Column("BudgetId")]
        public Guid Id { get; set; }=Guid.NewGuid();
        [Required(ErrorMessage = "Name value is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Amount value is required")]
        public decimal TotalAmount { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow; // Ensure UTC DateTime
        public DateTime? EndDate { get; set; }   // Ensure UTC DateTime
        public ICollection<BudgetCategory> Categories { get; set; } = new List<BudgetCategory>();

    }
}
