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
    public class AddEditSalesPersonRepository : IAddEditSalesPersonService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public AddEditSalesPersonRepository(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> AddToCartProduct(AddToCartDto addToCartDto)
        {
            try
            {
                var cartItems = await _repositoryManager.shoppingCartItem.GetShoppingCartItemAsync(addToCartDto.ProductId, trackChanges: true);

                if (cartItems == null)
                {
                    ShoppingCartItem cartItem = new ShoppingCartItem();

                    cartItem.ProductId = addToCartDto.ProductId;
                    cartItem.ShoppingCartId = addToCartDto.CustomerId;
                    cartItem.Quantity = 1;
                    cartItem.ModifiedDate = DateTime.Now;
                    cartItem.DateCreated = DateTime.Now;

                    _repositoryManager.shoppingCartItem.CreateShoppingCartItem(cartItem);
                    await _repositoryManager.SaveAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                _loggerManager.LogWarn($"message : {ex.Message}");
                return false;
            }
            

        }

        public async Task<bool> SaveSalesPerson(AddEditSalesPersonDto addEditSalesPersonDto)
        {
            try
            {
                var person = await _repositoryManager.SalesPerson.GetSalesPersonAsync(addEditSalesPersonDto.BusinessEntityId, trackChanges: true);
                var salesPersonQuotaHistory = await _repositoryManager.SalesPersonQuotaHistory.GetSalesPersonQuotaHistoryByIdAsync(addEditSalesPersonDto.BusinessEntityId, trackChanges: false);

                if (person == null)
                {
                    person.SalesQuota = salesPersonQuotaHistory.SalesQuota;
                    person.TerritoryId = addEditSalesPersonDto.TerritoryId;
                    person.Bonus = 0;
                    person.CommissionPct = 0;
                    person.SalesYtd = 0;
                    person.SalesLastYear = 0;

                    _repositoryManager.SalesPerson.CreateSalesPersonAsync(person);
                    await _repositoryManager.SaveAsync();
                }

                person.TerritoryId = addEditSalesPersonDto.TerritoryId;
                _repositoryManager.SalesPerson.UpdateSalesPersonAsync(person);
                await _repositoryManager.SaveAsync();

                if (addEditSalesPersonDto.stores != null)
                {
                    foreach (var item in addEditSalesPersonDto.stores)
                    {
                        var store = await _repositoryManager.Store.GetStoreAsync(item, trackChanges: true);
                        store.SalesPersonId = person.BusinessEntityId;

                        _repositoryManager.Store.UpdateStoreAsync(store);
                        await _repositoryManager.SaveAsync();
                    }
                }
                

                return true;
            }
            catch (Exception ex)
            {
                _loggerManager.LogWarn($"message : {ex.Message}");
                return false;    
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
