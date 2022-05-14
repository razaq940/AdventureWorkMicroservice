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
        Task<Store> GetStoreAsync(string name, bool trackChanges);
        Task<Store> GetStoreByIdAsync(int id, bool trackChanges);
        void CreateStoreAsync(Store store);
        void UpdateStoreAsync(Store store);
        void DeleteStoreAsync(Store store);
    }
}
