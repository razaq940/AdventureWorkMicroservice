using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface
{
    public interface ISalesOrderDetailRepository
    {
        Task<IEnumerable<SalesOrderDetail>> GetAllSalesOrderDetailAsync(bool trackChanges);
        Task<SalesOrderDetail> GetSalesOrderDetailAsync(int salesOrderId, int salesOrderDetailId, bool trackChanges);
    }
}
