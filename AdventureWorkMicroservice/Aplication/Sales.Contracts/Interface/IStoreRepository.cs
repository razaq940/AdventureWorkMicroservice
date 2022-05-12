using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetAllStoreAsync(bool trackChanges);

        Task<Store> GetStoreAsync(int id, bool trackChanges);

        void CreateStore(Store store);

        void DeleteStore(Store store);
        void UpdateStore(Store store);

        
    }
}
