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
    public class ProductOnSaleService : IProductOnSaleService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public ProductOnSaleService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> AddToCartProduct(AddToCartDto addToCartDto)
        {
            try
            {
                var cartItems = await _repositoryManager.ShoppingCartItem.GetShoppingCartItemAsync(addToCartDto.ProductId, trackChanges: true);

                if (cartItems == null)
                {
                    ShoppingCartItem cartItem = new ShoppingCartItem();

                    cartItem.ProductId = addToCartDto.ProductId;
                    cartItem.ShoppingCartId = addToCartDto.CustomerId;
                    cartItem.Quantity = 1;
                    cartItem.ModifiedDate = DateTime.Now;
                    cartItem.DateCreated = DateTime.Now;

                    _repositoryManager.ShoppingCartItem.CreateShoppingCartItem(cartItem);
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
    }
}
