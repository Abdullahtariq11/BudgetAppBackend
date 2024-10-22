using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Infrastructure.Configuration
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            // Configure relationship between Card and User
            builder.HasOne(c => c.User)
                   .WithMany(u => u.Cards)
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Configure relationship between Card and Transactions
            builder.HasMany(c => c.Transactions)
                   .WithOne(t => t.Card)
                   .HasForeignKey(t => t.CardId)
                   .OnDelete(DeleteBehavior.SetNull);

            // Seed data for Cards
            /*
            var userId = "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4"; // Use the correct user ID
            builder.HasData(
                new Card
                {
                    Id = Guid.Parse("54e0c90e-1e91-42d1-8d24-8e00fa63ec0b"),
                    cardType = CardType.Debit,
                    CardName = "Debit Card",
                    Balance = 1000,
                    UserId = userId
                },
                new Card
                {
                    Id = Guid.Parse("abf2b781-ea45-4d36-b5f7-3c6fd7e4bdf7"),
                    cardType = CardType.Credit,
                    CardName = "Credit Card",
                    Balance = -500,
                    AvailableBalance = 2000,
                    TotalCreditLimit = 2500,
                    UserId = userId
                }
            );
            */
        }
    }
}
