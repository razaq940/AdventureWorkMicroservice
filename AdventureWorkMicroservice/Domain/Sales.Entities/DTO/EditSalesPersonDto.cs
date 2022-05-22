using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.DTO
{
    public class EditSalesPersonDto
    {
        public int BusinessEntityId { get; set; }
        public string FullName { get; set; }
        public string NationalIdnumber { get; set; }
        public string JobTitle { get; set; }
        public int? TerritoryId { get; set; }
        public string Name { get; set; }
        public string CountryRegionCode { get; set; }
        public string Group { get; set; }
        public IEnumerable<string> StoreName { get; set; }
    }
}
