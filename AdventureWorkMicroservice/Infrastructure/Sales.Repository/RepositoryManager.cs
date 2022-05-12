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

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
