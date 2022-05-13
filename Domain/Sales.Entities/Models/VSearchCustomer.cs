using System;
using System.Collections.Generic;

#nullable disable

namespace Sales.Entities.Models
{
    public partial class VSearchCustomer
    {
        public int CustomerId { get; set; }
        public string PersonType { get; set; }
        public string FullName { get; set; }
        public int? StoreId { get; set; }
        public string StoreName { get; set; }
        public string Territory { get; set; }
    }
}
