using System;
using System.Collections.Generic;

#nullable disable

namespace Sales.Entities.Models
{
    public partial class VProductOnSale
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string UnitMeasure { get; set; }
        public int AvailableStock { get; set; }
        public string Category { get; set; }
    }
}
