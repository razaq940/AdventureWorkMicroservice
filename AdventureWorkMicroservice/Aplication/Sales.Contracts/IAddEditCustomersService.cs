using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.Entities.Models;
using Sales.Entities.DTO.AECDTO;

namespace Sales.Contracts
{
    public interface IAddEditCustomersService
    {
        Task<IEnumerable<Person>> SearchPersonByName(string personName);
        Task<IEnumerable<SalesTerritory>> SearchSalesTeritoryByTeritoryId(int teritoryId);
        Task<IEnumerable<Store>> SearchStoreByPersonId(int personId);
        Task<bool> SaveAddEditCustomer(CustomerPersonAECDTO customerPersonAECDTO);
    }
}
