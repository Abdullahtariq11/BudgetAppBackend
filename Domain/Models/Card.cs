using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace BudgetApp.Domain.Models
{
    public class Card
    {
        [Column("CardId")]
        public Guid Id { get; set; } = Guid.NewGuid();
        public CardType cardType { get; set; } // e.g., Debit, Credit
        // Card subtype: Savings, Chequing (for Debit cards only)
        public SubCardType? subCardType { get; set; } // Nullable because it only applies for Debit cards

        [Required(ErrorMessage = "Card name is required")]
        public required string CardName { get; set; } 
        public decimal? Balance { get; set; }
        
        public decimal? AvailableBalance { get; set; } // Nullable for non-credit cards
        public decimal? TotalCreditLimit { get; set; } // Nullable for non-credit cards

        // Foreign key and navigation property
        [Required(ErrorMessage = "userId is required")]
        public string? UserId { get; set; }
        public User? User { get; set; }

        // Transactions associated with this card
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
    public enum CardType
    {
        Debit,
        Credit
    }
    public enum SubCardType
    {
        None=0,
        Savings=1,
        Chequing=2
    }
    
}
