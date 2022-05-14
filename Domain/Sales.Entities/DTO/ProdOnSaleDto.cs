using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.DTO
{
    public class ProdOnSaleDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string UnitMeasure { get; set; }
        public int AvailableStock { get; set; }
    }
}
