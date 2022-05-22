using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.DTO
{
    public class AddEditSalesPersonDto
    {
        public int BusinessEntityId { get; set; }
        public int TerritoryId { get; set; }
        public decimal? SalesQuota { get; set; }
        public decimal Bonus { get; set; }
        public decimal CommissionPct { get; set; }
        public decimal SalesYtd { get; set; }
        public decimal SalesLastYear { get; set; }  
        public IEnumerable<string>? stores { get; set; }
    }
}
