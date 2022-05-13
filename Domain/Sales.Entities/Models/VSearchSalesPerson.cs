using System;
using System.Collections.Generic;

#nullable disable

namespace Sales.Entities.Models
{
    public partial class VSearchSalesPerson
    {
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public string EmailAddress { get; set; }
        public decimal? SalesQuota { get; set; }
        public decimal Bonus { get; set; }
        public decimal CommissionPct { get; set; }
        public decimal SalesYtd { get; set; }
        public decimal SalesLastYear { get; set; }
        public string Territory { get; set; }
    }
}
