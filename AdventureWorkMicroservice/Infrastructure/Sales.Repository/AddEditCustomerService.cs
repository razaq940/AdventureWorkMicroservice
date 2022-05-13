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

        

        
        public Task<bool> SaveAddEditCustomer(StoreAECDTO storeAECDTO, CustomerPersonAECDTO customerPersonAECDTO)
        {
            /*
            var person = new Person();

            var store = new Store();
            store.Name = storeAECDTO.Name;
            store.ModifiedDate = DateTime.Now;
            _repository.Store.CreateStore(store);
            _repository.SaveAsync();
            */
            throw new NotImplementedException();

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
                var stores =  _repository.Store.GetAllStoreAsync(trackChanges: false).Result.Where(c=>c.SalesPersonId==personId);
                return stores;
            }
            catch(Exception Ex)
            {
                
                return null;
            }
        }
    }
}
