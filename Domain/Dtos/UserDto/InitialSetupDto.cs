using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Domain.Dtos.BudgetCategoryDto;
using BudgetApp.Domain.Dtos.CardDto;

namespace Domain.Dtos.UserDto
{
    public class InitialSetupDto
    {
        [Required]
        public CreatedCardDto? Card { get; set; }
        [Required]
        public CreatedCategoryDto? Category1 { get;set; }
        [Required]
        public CreatedCategoryDto? Category2 { get; set; }
    }
}