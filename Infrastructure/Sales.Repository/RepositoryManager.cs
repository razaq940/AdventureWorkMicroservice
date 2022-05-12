using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.Contracts;
using Sales.Contracts.Interface;
using Sales.Entities.Contexts;
using Sales.Repository.Models;

namespace Sales.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICustomerRepository _customersRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ICustomerRepository Customers
        {
            get
            {
                if (_customersRepository == null)
                {
                    _customersRepository = new CustomerRepository(_repositoryContext);
                }
                return _customersRepository;
            }

        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
            
        
    }
}
