using System;
using System.Collections.Generic;

#nullable disable

namespace Sales.Entities.Models
{
    public partial class CountryRegionCurrency
    {
        public string CountryRegionCode { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Currency CurrencyCodeNavigation { get; set; }
    }
}
