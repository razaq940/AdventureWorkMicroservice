using Sales.Entities.DTO;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts
{
    public interface IAddEditSalesPersonService
    {
        Task<SalesTerritory> SearchSalesTerritoryById(int territoryId, AddEditSalesPersonDto addEditSalesPersonDto);
        Task<IEnumerable<Store>> SearchStore(string name);
        Task<IEnumerable<vEmployeePerson>> SeacrhEmployeePerson(string name);
        Task<SalesPerson> SaveSalesPerson(AddEditSalesPersonDto addEditSalesPersonDto);
        Task<EditSalesPersonDto> GetEditSalesPerson(int salesPersonId);
        Task<Store> AddStoreAsync(StoreDto storeDto);
        Task<Store> DeleteStoreAsync(StoreDto storeDto);
    }
}
