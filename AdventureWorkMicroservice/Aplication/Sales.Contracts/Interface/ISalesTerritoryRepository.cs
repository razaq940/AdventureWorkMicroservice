using Sales.Entities.Models;
using Sales.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface
{
    public interface ISalesTerritoryRepository
    {
        Task<IEnumerable<SalesTerritory>> GetAllSalesTerritoryAsync(bool trackChanges);
        Task<SalesTerritory> GetSalesTerritory(int id, bool trackChanges);
    }
}
