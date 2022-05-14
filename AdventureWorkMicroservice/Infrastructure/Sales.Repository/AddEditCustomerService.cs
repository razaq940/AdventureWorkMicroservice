using AutoMapper;
using Sales.Contracts;
using Sales.Entities.DTO.AECDTO;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sales.Repository
{
    public class AddEditCustomerService : IAddEditCustomersService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public AddEditCustomerService(IRepositoryManager repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
        }

        

        
        public async Task<bool> SaveAddEditCustomer(CustomerPersonAECDTO customerPersonAECDTO)
        {
            /*di mokap ini hanya bisa 
             * adit store("add store tidak bisa"), 
             * add customer dengan type individual("tidak bisa add customer dengan type store"),
             * edit customer type individual dan store
             **/
            try
            {
                
                var store = await _repository.Store.GetStoreAsync(customerPersonAECDTO.BusinessEntityId, trackChanges: true);
                //edit store name
                if (customerPersonAECDTO.NameStore != store.Name )
                {
                    store.Name = customerPersonAECDTO.NameStore;
                    _repository.Store.UpdateStore(store);
                    await _repository.SaveAsync();
                }
                
                var cstmr = _repository.Customers.GetAllCustomerAsync(trackChanges: true).Result.Where(c => c.PersonId == customerPersonAECDTO.BusinessEntityId || c.StoreId == customerPersonAECDTO.BusinessEntityId ).FirstOrDefault();
                //add new customer
                if (cstmr == null)
                {
                    
                    cstmr.PersonId = customerPersonAECDTO.BusinessEntityId;
                    cstmr.ModifiedDate = DateTime.UtcNow;
                    cstmr.TerritoryId = customerPersonAECDTO.TerritoryId;
                    _repository.Customers.CreateCustomer(cstmr);
                    await _repository.SaveAsync();
                    return true;
                }
                //edit customer
                cstmr.TerritoryId = customerPersonAECDTO.TerritoryId;
                _repository.Customers.UpdateCustomer(cstmr);
                await _repository.SaveAsync();
                return true;

                
            }
            catch (Exception ex)
            {
                return false;
            }

            
            //throw new NotImplementedException();

        }
        
        public async Task<IEnumerable<Person>> SearchPersonByName(string personName)
        {
            try
            {
                var person =  _repository.Person.GetAllPersonAsync(trackChanges:false).Result.Where(c=>(c.FirstName+c.MiddleName+c.LastName).Contains(personName));
                return person;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<SalesTerritory>> SearchSalesTeritoryByTeritoryId(int teritoryId)
        {
            var salesTerritory =  _repository.SalesTerritory.GetAllSalesTerritoryAsync(trackChanges: false).Result.Where(c=>c.TerritoryId == teritoryId);
            return salesTerritory;
        }

        public async Task<IEnumerable<Store>> SearchStoreByPersonId(int personId)
        {
            try
            {
                var stores =  _repository.Store.GetAllStoreAsync(trackChanges: false).Result.Where(c=>c.BusinessEntityId==personId);

                return stores;
            }
            catch(Exception Ex)
            {
                
                return null;
            }
        }
    }
}
