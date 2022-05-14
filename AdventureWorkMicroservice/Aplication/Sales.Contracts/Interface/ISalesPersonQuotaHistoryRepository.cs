using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface
{
    public interface ISalesPersonQuotaHistoryRepository
    {
        Task<IEnumerable<SalesPersonQuotaHistory>> GetAllSalesPersonQuotaHistoryAsync(bool trackChanges);
        Task<SalesPersonQuotaHistory> GetSalesPersonQuotaHistoryByIdAsync(int id, bool trackChanges);
        void CreateSalesPersonQuotaHistory(SalesPersonQuotaHistory salesPersonQuotaHistory);
        void UpdateSalesPersonQuotaHistory(SalesPersonQuotaHistory salesPersonQuotaHistory);
        void DeleteSalesPersonQuotaHistory(SalesPersonQuotaHistory salesPersonQuotaHistory);
    }
}
