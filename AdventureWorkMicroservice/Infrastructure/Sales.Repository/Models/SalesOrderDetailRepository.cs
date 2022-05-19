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
    public class SalesOrderDetailRepository : RepositoryBase<SalesOrderDetail>, ISalesOrderDetailRepository
    {
        public SalesOrderDetailRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<SalesOrderDetail>> GetAllSalesOrderDetailAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                    .OrderBy(sod => sod.SalesOrderId)
                    .ToListAsync();

        public async Task<SalesOrderDetail> GetSalesOrderDetailAsync(int salesOrderId, int salesOrderDetailId, bool trackChanges) =>
            await FindByCondition(sod => 
                    sod.SalesOrderId.Equals(salesOrderId) && sod.SalesOrderDetailId.Equals(salesOrderDetailId),
                    trackChanges).SingleOrDefaultAsync();
    }
}
