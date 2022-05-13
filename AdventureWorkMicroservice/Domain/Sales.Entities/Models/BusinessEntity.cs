using System;
using System.Collections.Generic;

#nullable disable

namespace Sales.Entities.Models
{
    public partial class BusinessEntity
    {
        public int BusinessEntityId { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
