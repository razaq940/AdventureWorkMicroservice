using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface
{
    public interface IShoppingCartItemRepository
    {
        Task<IEnumerable<ShoppingCartItem>> GetAllShoppingCartItemsAsync(bool trackChanges);
        Task<ShoppingCartItem> GetShoppingCartItemAsync(int id, bool trackChanges);
        void CreateShoppingCartItem(ShoppingCartItem shoppingCartItem);
        void UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem);
        void DeleteShoppingCartItem(ShoppingCartItem shoppingCartItem);
    }
}
