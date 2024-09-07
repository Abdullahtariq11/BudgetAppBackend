using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Domain.Models
{
    public class Transaction
    {
        [Column("TransactionId")]
        public Guid Id { get; set; }= Guid.NewGuid();
        [Required(ErrorMessage ="Amount value is required")]
        public decimal Amount { get; set; }

        public TransactionType Type { get; set; }

        [Required(ErrorMessage = "Category value is required")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "Transaction date value is required")]
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        [MaxLength(60,ErrorMessage ="Maximum Length for Description is 60 characters")]
        public string? Description { get; set; }


        /// <summary>
        /// Foreign key and navigation property
        /// </summary>

        [Required(ErrorMessage ="userId is required")]
        public string? UserID { get; set; }
        public User? User { get; set; }

        
        public Guid? CardId { get; set; }
        public Card? Card { get; set; }



    }
    public enum TransactionType
    {
        Income,
        Expense
    }
}
