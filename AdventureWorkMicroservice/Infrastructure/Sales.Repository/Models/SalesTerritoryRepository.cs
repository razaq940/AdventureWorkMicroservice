using Microsoft.EntityFrameworkCore;
using Sales.Contracts.Interface;
using Sales.Entities.Models;
using Sales.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repository.Models
{
    public class SalesTerritoryRepository : RepositoryBase<SalesTerritory>, ISalesTerritoryRepository
    {
        public SalesTerritoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<SalesTerritory>> GetAllSalesTerritoryAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(st => st.Name)
                .ToListAsync();

        public async Task<SalesTerritory> GetSalesTerritory(int id, bool trackChanges) =>
            await FindByCondition(st => st.TerritoryId.Equals(id), trackChanges).SingleOrDefaultAsync();

    }
}
