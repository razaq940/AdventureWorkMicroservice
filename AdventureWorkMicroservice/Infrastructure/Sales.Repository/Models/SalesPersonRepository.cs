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

        public void CreateSalesPersonAsync(SalesPerson salesPerson)
        {
            Create(salesPerson);
        }

        public void DeleteSalesPersonAsync(SalesPerson salesPerson)
        {
            Delete(salesPerson);
        }

        public async Task<IEnumerable<SalesPerson>> GetAllSalesPersonAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                    .OrderBy(sp => sp.BusinessEntityId)
                    .ToListAsync();

        public async Task<SalesPerson> GetSalesPersonAsync(int id, bool trackChanges) =>
            await FindByCondition(sp => sp.BusinessEntityId.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateSalesPersonAsync(SalesPerson salesPerson)
        {
            Update(salesPerson);
        }
    }
}
