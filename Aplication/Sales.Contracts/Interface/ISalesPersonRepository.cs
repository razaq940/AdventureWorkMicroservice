using Sales.Entities.Models;
using Sales.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface
{
    public interface ISalesPersonRepository
    {
        Task<IEnumerable<VSearchSalesPerson>> SearchSalesPerson(SalesPersonParameters customerParameters, bool trackChanges);
    }
}
