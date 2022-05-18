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
    public class ShoppingCartItemRepository : RepositoryBase<ShoppingCartItem>, IShoppingCartItemRepository
    {
        public ShoppingCartItemRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            Create(shoppingCartItem);
        }

        public void DeleteShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            Delete(shoppingCartItem);
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetAllShoppingCartItemsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                    .OrderBy(ct => ct.ShoppingCartId)
                    .ToListAsync();

        public async Task<ShoppingCartItem> GetShoppingCartItemAsync(int id, bool trackChanges) =>
            await FindByCondition(ct => ct.ShoppingCartId.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            Update(shoppingCartItem);
        }
    }
}
