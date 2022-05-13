using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface.AECInterface
{
    public interface ISalesTerritoryRepository
    {
        Task<IEnumerable<SalesTerritory>> GetAllSalesTerritoryAsync(bool trackChanges);

        Task<SalesTerritory> GetSalesTerritoryAsync(int id, bool trackChanges);

        void CreateSalesTerritory(SalesTerritory salesTerritory);

        void DeleteSalesTerritory(SalesTerritory salesTerritory);
        void UpdateSalesTerritory(SalesTerritory salesTerritory);
    }
}
