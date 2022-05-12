using Microsoft.EntityFrameworkCore;
using Sales.Contracts.Interface;
using Sales.Entities.Contexts;
using Sales.Entities.Models;
using Sales.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repository.Models
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCustomerAsync(Customer customer)
        {
            Create(customer);
        }

        public void DeleteCustomerAsync(Customer customer)
        {
            Delete(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomerAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(c => c.CustomerId)
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(string id, bool trackChanges) =>
            await FindByCondition(c => c.CustomerId.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Customer>> GetPaginationCustomerAsync(CustomerParameters customerParameters, bool trackChanges)
        {
            return await FindAll(trackChanges)
             .OrderBy(c => c.CustomerId)
             .Skip((customerParameters.PageNumber - 1) * customerParameters.PageSize)
             .Take(customerParameters.PageSize)
             .ToListAsync();
        }

        public async Task<IEnumerable<Customer>> SearchCustomer(CustomerParameters customerParameters, bool trackChanges)
        {
            if (string.IsNullOrWhiteSpace(customerParameters.SearchCust))
            {
                return await FindAll(trackChanges).ToListAsync();
            }

            var lowerCaseSearch = customerParameters.SearchCust.Trim().ToLower();
            return await FindAll(trackChanges)
            .Where(c=> c.CustomerId.ToString().ToLower() == lowerCaseSearch)
            .OrderBy(c => c.CustomerId)
            .Skip((customerParameters.PageNumber - 1) * customerParameters.PageSize)
            .Take(customerParameters.PageSize)
            .ToListAsync();
        }

        public void UpdateCustomerAsync(Customer customer)
        {
            Update(customer);
        }
    }
}
