using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BudgetApp.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            /// Configure relationship with transactions
            builder.HasMany(u => u.Transactions)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            /// Configure relationship with Budget Categories
            builder.HasMany(u => u.BudgetCategories)
                .WithOne(bc => bc.User)
                .HasForeignKey(bc => bc.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            /// Configure relationship with cards
            builder.HasMany(u => u.Cards)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed data for User
            var userId = "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4";
            var user = new User
            {
                Id = userId,
                UserName = "abdullahT",
                NormalizedUserName = "ABDULLAHT",
                Email = "abdullahtariq096@gmail.com",
                NormalizedEmail = "ABDULLAHTARIQ096@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Abdullah",
                LastName = "Tariq",
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "Sameen11."),
                
            };
            builder.HasData(user);
        }
    }
}
