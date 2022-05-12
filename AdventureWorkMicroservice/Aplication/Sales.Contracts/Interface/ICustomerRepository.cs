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

        Task<Customer> GetCustomerAsync(int id, bool trackChanges);

        void CreateCustomer(Customer customer);

        void DeleteCustomer(Customer customer);
        void UpdateCustomer(Customer customer);

        Task<IEnumerable<Customer>> GetPaginationCustomersAsync(CustomerParameters categoryParameters, bool trackChanges);

        Task<IEnumerable<Customer>> SearchCustomer(CustomerParameters categoryParameters, bool trackChange);
    }
}
