using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface
{
    public interface ISalesOrderHeaderRepository
    {
        Task<IEnumerable<SalesOrderHeader>> GetAllSalesOrderHeaderAsync(bool trackChanges);
        Task<SalesOrderHeader> GetSalesOrderHeaderAsync(int id, bool trackChanges);
        void CreateSalesOrderHeader(SalesOrderHeader salesOrderHeader);
        void UpdateSalesOrderHeader(SalesOrderHeader salesOrderHeader);
        void DeleteSalesOrderHeader(SalesOrderHeader salesOrderHeader);
    }
}
