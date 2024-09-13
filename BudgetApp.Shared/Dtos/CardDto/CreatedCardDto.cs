using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Shared.Dtos.CardDto
{
    public record CreatedCardDto(string CardName,decimal Balance,decimal AvailableBalance,decimal TotalCreditLimit,string cardType);

}