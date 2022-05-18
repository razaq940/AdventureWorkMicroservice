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
    public class SalesOrderHeaderRepository : RepositoryBase<SalesOrderHeader>, ISalesOrderHeaderRepository
    {
        public SalesOrderHeaderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateSalesOrderHeader(SalesOrderHeader salesOrderHeader)
        {
            Create(salesOrderHeader);
        }

        public void DeleteSalesOrderHeader(SalesOrderHeader salesOrderHeader)
        {
            Delete(salesOrderHeader);
        }

        public async Task<IEnumerable<SalesOrderHeader>> GetAllSalesOrderHeaderAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                    .OrderBy(soh => soh.SalesOrderId)
                    .ToListAsync();

        public async Task<SalesOrderHeader> GetSalesOrderHeaderAsync(int id, bool trackChanges) =>
            await FindByCondition(soh => soh.SalesOrderId.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateSalesOrderHeader(SalesOrderHeader salesOrderHeader)
        {
            Update(salesOrderHeader);
        }
    }
}
