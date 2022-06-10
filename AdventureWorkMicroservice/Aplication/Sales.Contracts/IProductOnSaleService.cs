using Sales.Entities.DTO;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts
{
    public interface IProductOnSaleService
    {
        Task<ShoppingCartItem> AddToCartProduct(AddToCartDto addToCartDto);
    }
}
