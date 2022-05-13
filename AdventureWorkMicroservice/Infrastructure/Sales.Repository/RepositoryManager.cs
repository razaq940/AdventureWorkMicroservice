using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.Contracts;
using Sales.Contracts.Interface.AECInterface;
using Sales.Entities.Contexts;
using Sales.Repository.Models;

namespace Sales.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICustomerRepository _customerRepository;
        private IStoreRepository _storeRepository;
        private IPersonRepository _personRepository;
        private ISalesTerritoryRepository _salesTerritoryRepository;
        private IBusinessEntityRepository _businessEntityRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ICustomerRepository Customers
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_repositoryContext);
                }
                return _customerRepository;
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

        public ISalesTerritoryRepository SalesTerritory
        {
            get
            {
                if (_salesTerritoryRepository == null)
                {
                    _salesTerritoryRepository = new SalesTerritoryRepository(_repositoryContext);
                }
                return _salesTerritoryRepository;
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

        

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }

        public async Task SaveAsync() =>
        
           await _repositoryContext.SaveChangesAsync();

        public async Task BeginTrans() =>
            await _repositoryContext.Database.BeginTransactionAsync();
        
        
    }
}
