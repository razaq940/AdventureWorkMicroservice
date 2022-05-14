using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.DTO.AECDTO
{
    public class CustomerPersonAECDTO
    {
        public int BusinessEntityId { get; set; }
        
        public int TerritoryId { get; set; }
        
        public string NameStore { get; set; }
    }
}
