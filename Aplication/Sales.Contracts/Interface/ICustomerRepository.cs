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
        Task<IEnumerable<VSearchCustomer>> SearchCustomer(CustomerParameters customerParameters, bool trackChanges);
    }
}
