using Sales.Contracts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts
{
    public interface IRepositoryManager
    {
        ISalesTerritoryRepository SalesTerritory { get; }
        IEmployeeRepository Employee { get; }
        IPersonRepository Person { get; }
        ISalesPersonRepository SalesPerson { get; }
        Task SaveAsync();
    }
}
