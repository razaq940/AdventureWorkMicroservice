using Sales.Contracts.Interface;
using Sales.Entities.Models;
using System;
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
    public class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {
        public StoreRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateStore(Store store)
        {
            Create(store);
        }

        public void DeleteStore(Store store)
        {
            Delete(store);
        }

       
        public async Task<IEnumerable<Store>> GetAllStoreAsync(bool trackChanges)
        {

            return await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }


        public async Task<Store> GetStoreAsync(int personId, bool trackChanges)
        {

            return await FindByCondition(c => c.BusinessEntityId.Equals(personId), trackChanges)
                .FirstOrDefaultAsync();
        }

        public void UpdateStore(Store store)
        {
            Update(store);
        }
    }
}
