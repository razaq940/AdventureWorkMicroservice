using Sales.Contracts.Interface;
using Sales.Entities.Models;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.Entities.Models;
using Sales.Contracts.Interface.AECInterface;
using Sales.Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Sales.Entities.RequestFeatures;
namespace Sales.Repository.Models
{
    public class SalesTerritoryRepository : RepositoryBase<SalesTerritory>, ISalesTerritoryRepository
    {
        public SalesTerritoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateSalesTerritory(SalesTerritory salesTerritory)
        {
            Create(salesTerritory);
        }

        public void DeleteSalesTerritory(SalesTerritory salesTerritory)
        {
            Delete(salesTerritory);
        }

        public async Task<IEnumerable<SalesTerritory>> GetAllSalesTerritoryAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<SalesTerritory> GetSalesTerritoryAsync(int id, bool trackChanges)
        {
            return await FindByCondition(c => c.TerritoryId.Equals(id), trackChanges)
                .FirstOrDefaultAsync();
        }

        public void UpdateSalesTerritory(SalesTerritory salesTerritory)
        {
            Update(salesTerritory);
        }
    }
}
