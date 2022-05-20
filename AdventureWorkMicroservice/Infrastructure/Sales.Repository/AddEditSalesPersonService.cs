using AutoMapper;
using Sales.Contracts;
using Sales.Entities.DTO;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repository
{
    public class AddEditSalesPersonService : IAddEditSalesPersonService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public AddEditSalesPersonService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<SalesPerson> SaveSalesPerson(AddEditSalesPersonDto addEditSalesPersonDto)
        {
            try
            {
                var salesPerson = await _repositoryManager.SalesPerson.GetSalesPersonAsync(addEditSalesPersonDto.BusinessEntityId, trackChanges: true);
                var salesPersonQuotaHistory = await _repositoryManager.SalesPersonQuotaHistory.GetSalesPersonQuotaHistoryByIdAsync(addEditSalesPersonDto.BusinessEntityId, trackChanges: false);

                if (salesPerson == null)
                {
                    salesPerson = new SalesPerson();

                    salesPerson.BusinessEntityId = addEditSalesPersonDto.BusinessEntityId;
                    if (salesPersonQuotaHistory != null)
                    {
                        salesPerson.SalesQuota = salesPersonQuotaHistory.SalesQuota;
                    }

                    salesPerson.Bonus = 0;
                    salesPerson.CommissionPct = 0;
                    salesPerson.SalesYtd = 0;
                    salesPerson.SalesLastYear = 0;

                    _repositoryManager.SalesPerson.CreateSalesPersonAsync(salesPerson);
                    await _repositoryManager.SaveAsync();
                }

                salesPerson.TerritoryId = addEditSalesPersonDto.TerritoryId;
                _repositoryManager.SalesPerson.UpdateSalesPersonAsync(salesPerson);
                await _repositoryManager.SaveAsync();

                if (addEditSalesPersonDto.stores != null)
                {
                    foreach (var item in addEditSalesPersonDto.stores)
                    {
                        var store = await _repositoryManager.Store.GetStoreAsync(item, trackChanges: true);
                        store.SalesPersonId = salesPerson.BusinessEntityId;

                        _repositoryManager.Store.UpdateStoreAsync(store);
                        await _repositoryManager.SaveAsync();
                    }
                }
                
                return salesPerson;
            }
             catch (Exception ex)
            {
                _loggerManager.LogWarn($"message : {ex.Message}");
                return null;    
            }
            
        }

        public async Task<IEnumerable<vEmployeePerson>> SeacrhEmployeePerson(string name)
        {
            var employeePersons = _repositoryManager.EmployeePerson.GetAllVEmployeePersonAsync(trackChanges: false).Result.Where(ep => ep.FullName == name);
            /*var employeePersonDto = _mapper.Map<vEmployeePerson>(employeePersons);*/
            return employeePersons;
        }

        public async Task<SalesTerritory> SearchSalesTerritoryById(int territoryId, AddEditSalesPersonDto addEditSalesPersonDto)
        {
            var territory = await _repositoryManager.SalesTerritory.GetSalesTerritory(territoryId, trackChanges: true);
            var territoryDto = _mapper.Map<SalesTerritory>(territory);
            return territoryDto;
        }

        public async Task<IEnumerable<Store>> SearchStore(string name)
        {
            var stores =  _repositoryManager.Store.GetAllStoreAsync(trackChanges: false).Result.Where(s => s.Name == name);
            return stores;
        }
    }
}
