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
    public class SalesPersonQuotaHistoryRepository : RepositoryBase<SalesPersonQuotaHistory>, ISalesPersonQuotaHistoryRepository
    {
        public SalesPersonQuotaHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateSalesPersonQuotaHistory(SalesPersonQuotaHistory salesPersonQuotaHistory)
        {
            Create(salesPersonQuotaHistory);
        }

        public void DeleteSalesPersonQuotaHistory(SalesPersonQuotaHistory salesPersonQuotaHistory)
        {
            Delete(salesPersonQuotaHistory);
        }

        public async Task<IEnumerable<SalesPersonQuotaHistory>> GetAllSalesPersonQuotaHistoryAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                    .OrderBy(q => q.BusinessEntityId)
                    .ToListAsync();

        public async Task<SalesPersonQuotaHistory> GetSalesPersonQuotaHistoryByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(q => q.BusinessEntityId.Equals(id), trackChanges).FirstOrDefaultAsync();

        public void UpdateSalesPersonQuotaHistory(SalesPersonQuotaHistory salesPersonQuotaHistory)
        {
            Update(salesPersonQuotaHistory);
        }
    }
}
