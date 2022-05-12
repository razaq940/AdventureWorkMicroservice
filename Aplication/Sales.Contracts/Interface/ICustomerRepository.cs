using Sales.Entities.Models;
using Sales.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomerAsync(bool trackChanges);
        Task<Customer> GetCustomerAsync(string id, bool trackChanges);
        Task<IEnumerable<Customer>> GetPaginationCustomerAsync(CustomerParameters customerParameters, bool trackChanges);
        Task<IEnumerable<Customer>> SearchCustomer(CustomerParameters customerParameters, bool trackChanges);
        void CreateCustomerAsync(Customer customer);

        void DeleteCustomerAsync(Customer customer);

        void UpdateCustomerAsync(Customer customer);
    }
}
