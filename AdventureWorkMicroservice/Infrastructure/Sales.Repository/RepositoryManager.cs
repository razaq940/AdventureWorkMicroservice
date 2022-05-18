using Sales.Contracts;
using Sales.Contracts.Interface;
using Sales.Entities.Models;
using Sales.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ISalesTerritoryRepository _salesTerritory;
        private IEmployeeRepository _employeeRepository;
        private IPersonRepository _personRepository;
        private ISalesPersonRepository _salesPersonRepository;
        private IStoreRepository _storeRepository;
        private IBusinessEntityRepository _businessEntityRepository;
        private IVEmployeePersonRepository _vemployeePersonRepository;
        private ISalesPersonQuotaHistoryRepository _salesPersonQuotaHistoryRepository;
        private IShoppingCartItemRepository _shoppingCartItemRepository;
        private IShipMethodRepository _shipMethodRepository;
        private ISalesOrderHeaderRepository _salesOrderHeaderRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ISalesTerritoryRepository SalesTerritory
        {
            get
            {
                if (_salesTerritory == null)
                {
                    _salesTerritory = new SalesTerritoryRepository(_repositoryContext);
                }
                return _salesTerritory;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_repositoryContext);
                }
                return _employeeRepository;
            }
        }

        public IPersonRepository Person
        {
            get
            {
                if (_personRepository == null)
                {
                    _personRepository = new PersonRepository(_repositoryContext);
                }
                return _personRepository;
            }
        }

        public ISalesPersonRepository SalesPerson
        {
            get
            {
                if (_salesPersonRepository == null)
                {
                    _salesPersonRepository = new SalesPersonRepository(_repositoryContext);
                }
                return _salesPersonRepository;
            }
        }
        public IStoreRepository Store
        {
            get
            {
                if (_storeRepository == null)
                {
                    _storeRepository = new StoreRepository(_repositoryContext);
                }
                return _storeRepository;
            }
        }

        public IBusinessEntityRepository BusinessEntity
        {
            get
            {
                if (_businessEntityRepository == null)
                {
                    _businessEntityRepository = new BusinessEntityRepository(_repositoryContext);
                }
                return _businessEntityRepository;
            }
        }

        public IVEmployeePersonRepository EmployeePerson
        {
            get
            {
                if (_vemployeePersonRepository == null)
                {
                    _vemployeePersonRepository = new VEmployeePersonRepository(_repositoryContext);
                }
                return _vemployeePersonRepository;
            }
        }

        public ISalesPersonQuotaHistoryRepository SalesPersonQuotaHistory
        {
            get
            {
                if (_salesPersonQuotaHistoryRepository == null)
                {
                    _salesPersonQuotaHistoryRepository = new SalesPersonQuotaHistoryRepository(_repositoryContext);
                }
                return _salesPersonQuotaHistoryRepository;
            }
        }

        public IShoppingCartItemRepository ShoppingCartItem
        {
            get
            {
                if (_shoppingCartItemRepository == null)
                {
                    _shoppingCartItemRepository = new ShoppingCartItemRepository(_repositoryContext);
                }
                return _shoppingCartItemRepository;
            }
        }

        public IShipMethodRepository ShipMethod
        {
            get
            {
                if (_shipMethodRepository == null)
                {
                    _shipMethodRepository = new ShipMethodRepository(_repositoryContext);
                }
                return _shipMethodRepository;
            }
        }

        public ISalesOrderHeaderRepository SalesOrderHeader
        {
            get
            {
                if (_salesOrderHeaderRepository == null)
                {
                    _salesOrderHeaderRepository = new SalesOrderHeaderRepository(_repositoryContext);
                }
                return _salesOrderHeaderRepository;
            }
        }
        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
