using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface
{
    public interface ISalesPersonRepository
    {
        Task<IEnumerable<SalesPerson>> GetAllSalesPersonAsync(bool trackChanges);
        Task<SalesPerson> GetSalesPersonAsync(int id, bool trackChanges);
    }
}
