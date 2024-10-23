using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Domain.Models; // Use the correct namespace

namespace BudgetApp.Domain.Dtos.TransactionDto
{
    public record TransactionsDto(ICollection<Transaction> transactions,int? pageSize,int? pageNumber,int totalItems);
}