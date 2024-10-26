using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dtos.TransactionDto
{
    public record UpdateTransactionDto(decimal amount,string transactionType,
    string category,DateTime transactionDate,string description,Guid budgetCategoryId);
}