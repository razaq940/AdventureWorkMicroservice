using Microsoft.EntityFrameworkCore;
using Sales.Contracts.Interface;
using Sales.Entities.Contexts;
using Sales.Entities.Models;
using Sales.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repository.Models
{
    public class ProductOnSaleRepository : RepositoryBase<VProductOnSale>, IProductOnSaleRepository
    {


        public ProductOnSaleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<VProductOnSale>> SearchProductOnSale(ProductOnSaleParameters productOnSaleParameters, bool trackChanges)
        {
            if (string.IsNullOrWhiteSpace(productOnSaleParameters.SearchProdOnSale))
            {
                return await FindAll(trackChanges).ToListAsync();
            }

            var lowerCaseSearch = productOnSaleParameters.SearchProdOnSale.Trim().ToLower();
            return await FindAll(trackChanges)
            .Where(c => c.Name.ToLower().Contains(lowerCaseSearch) || c.Category.ToLower().Contains(lowerCaseSearch))
            .Skip((productOnSaleParameters.PageNumber - 1) * productOnSaleParameters.PageSize)
            .Take(productOnSaleParameters.PageSize)
            .ToListAsync();
        }
    }
}
