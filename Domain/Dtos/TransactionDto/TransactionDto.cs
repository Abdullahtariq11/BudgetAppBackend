using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace BudgetApp.Domain.Dtos.TransactionDto
{
    public record TransactionDto(decimal amount,string transactionType,
    string category,DateTime transactionDate,string description, Guid cardId,Guid? BudgetCategoryId);

}
