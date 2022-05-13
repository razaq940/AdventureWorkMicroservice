using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.Contracts.Interface.AECInterface;

namespace Sales.Contracts
{
    public interface IRepositoryManager
    {

        ICustomerRepository Customers { get; }
        IStoreRepository Store { get; }
        IPersonRepository Person { get; }
        ISalesTerritoryRepository SalesTerritory { get; }

        IBusinessEntityRepository BusinessEntity { get; }

        void Save();
        Task SaveAsync();

    }
}
