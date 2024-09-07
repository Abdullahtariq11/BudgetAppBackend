using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Shared.RequestFeatures
{
    public class TransactionParameter:RequestParameter
    {
        public string? FilterOn { get; set; }
        public string? FilterQuery { get; set; }
      


        public bool HasValidFilter() =>
                !string.IsNullOrWhiteSpace(FilterQuery) && !string.IsNullOrWhiteSpace(FilterOn);
    }
}
