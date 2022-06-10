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

        public async Task<ShoppingCartItem> AddToCartProduct(AddToCartDto addToCartDto)
        {
            try
            {
                var cartItems = _repositoryManager.ShoppingCartItem.GetAllShoppingCartItemsAsync(trackChanges: true)
                                .Result.Where(ci => ci.ProductId == addToCartDto.ProductId && ci.ShoppingCartId == addToCartDto.CustomerId)
                                .SingleOrDefault();

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
                else
                {
                    cartItems.Quantity += 1;
                    _repositoryManager.ShoppingCartItem.UpdateShoppingCartItem(cartItems);
                    await _repositoryManager.SaveAsync();
                }

                return cartItems;
            }
            catch (Exception ex)
            {
                _loggerManager.LogWarn($"message : {ex.Message}");
                return null;
            }
        }
    }
}
