using Microsoft.EntityFrameworkCore;
using Sales.Contracts.Interface;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repository.Models
{
    public class SalesPersonRepository : RepositoryBase<SalesPerson>, ISalesPersonRepository
    {
        public SalesPersonRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<SalesPerson>> GetAllSalesPersonAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                    .OrderBy(sp => sp.BusinessEntityId)
                    .ToListAsync();

        public async Task<SalesPerson> GetSalesPersonAsync(int id, bool trackChanges) =>
            await FindByCondition(sp => sp.BusinessEntityId.Equals(id), trackChanges).SingleOrDefaultAsync();
    }
}
