using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.Entities.Models;
using Sales.Contracts.Interface.AECInterface;
using Sales.Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Sales.Entities.RequestFeatures;

namespace Sales.Repository.Models
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            Delete(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomerAsync(bool trackChanges)
        {
                   
            return await FindAll(trackChanges)
                .OrderBy(c => c.AccountNumber)
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(int id, bool trackChanges)
        {
            
            return await FindByCondition(c => c.CustomerId.Equals(id), trackChanges)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Customer>> GetPaginationCustomersAsync(CustomerParameters customerParameters, bool trackChanges)
        {
            return await FindAll(trackChanges)
                 .OrderBy(c => c.AccountNumber)
                 .Skip((customerParameters.PageNumber - 1) * customerParameters.PageSize)
                 .Take(customerParameters.PageSize)
                 .ToListAsync();
        }

        
        

        public async Task<IEnumerable<Customer>> SearchCustomer(CustomerParameters customerParameters, bool trackChange)
        {
            if (string.IsNullOrWhiteSpace(customerParameters.SearchCompany))
            {
                return await FindAll(trackChange).ToListAsync();
            }
            var lowerCaseSerach = customerParameters.SearchCompany.Trim().ToLower();
            return await FindAll(trackChange)
                .Where(c => c.AccountNumber.ToLower().Contains(lowerCaseSerach))
                .OrderBy(c => c.AccountNumber)
                .ToListAsync();
        }

        public void UpdateCustomer(Customer customer)
        {
            Update(customer);
        }

       
    }
}
