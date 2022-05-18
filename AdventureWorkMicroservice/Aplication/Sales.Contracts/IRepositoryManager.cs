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
        IStoreRepository Store { get; }
        IBusinessEntityRepository BusinessEntity { get; }
        IVEmployeePersonRepository EmployeePerson { get; }
        ISalesPersonQuotaHistoryRepository SalesPersonQuotaHistory { get; }
        IShoppingCartItemRepository ShoppingCartItem { get; }
        IShipMethodRepository ShipMethod { get; }
        ISalesOrderHeaderRepository SalesOrderHeader { get; }
        Task SaveAsync();
    }
}
