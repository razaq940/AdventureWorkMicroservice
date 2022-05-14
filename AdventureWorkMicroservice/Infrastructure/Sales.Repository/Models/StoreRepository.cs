using Microsoft.EntityFrameworkCore;
using Sales.Contracts.Interface;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repository.Models
{
    public class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {
        public StoreRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateStoreAsync(Store store)
        {
            Create(store);
        }

        public void DeleteStoreAsync(Store store)
        {
            Delete(store);
        }

        public async Task<IEnumerable<Store>> GetAllStoreAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(s => s.Name)
                .ToListAsync();

        public async Task<Store> GetStoreAsync(string name, bool trackChanges) =>
            await FindByCondition(s => s.Name.Contains(name), trackChanges).FirstOrDefaultAsync();

        public async Task<Store> GetStoreByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.BusinessEntityId.Equals(id), trackChanges).FirstOrDefaultAsync();

        public void UpdateStoreAsync(Store store)
        {
            Update(store);
        }
    }
}
