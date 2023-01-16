using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostHubLibrary.Model
{
    public class Cost
    {
        // Unique id for the cost
        public string CostId { get; set; }

        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public decimal OriginalAmount { get; set; }
        public string OriginalCurrency { get; set; }
        public decimal ExchangeRate { get; set; }
        public string ResourceId { get; set; }

        // Period covered by the cost
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Service { get; set; }

        // Cost name is used to match the cost to a resource 
        public string Name { get; set; }
    }
}
