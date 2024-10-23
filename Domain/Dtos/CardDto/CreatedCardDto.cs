using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Domain.Dtos.CardDto
{
    public record CreatedCardDto(Guid Id,string CardName,decimal? Balance,decimal? AvailableBalance,decimal? TotalCreditLimit,string? cardType,string? subCardType);

}