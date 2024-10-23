using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BudgetApp.Shared.Dtos.TransactionDto
{
    public record TransactionsDto(ICollection<Transaction>? transactions,int? pageSize,int? pageNumber,int totalItems);
}