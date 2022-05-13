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
    public class SalesPersonRepository : RepositoryBase<VSearchSalesPerson>, ISalesPersonRepository
    {
        public SalesPersonRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<VSearchSalesPerson>> SearchSalesPerson(SalesPersonParameters customerParameters, bool trackChanges)
        {
            if (string.IsNullOrWhiteSpace(customerParameters.SearchSalesPerson))
            {
                return await FindAll(trackChanges).ToListAsync();
            }

            var lowerCaseSearch = customerParameters.SearchSalesPerson.Trim().ToLower();
            return await FindAll(trackChanges)
            .Where(c => c.FullName.ToLower().Contains(lowerCaseSearch) || c.JobTitle.ToLower().Contains(lowerCaseSearch) || c.EmailAddress.ToLower().Contains(lowerCaseSearch))
            .Skip((customerParameters.PageNumber - 1) * customerParameters.PageSize)
            .Take(customerParameters.PageSize)
            .ToListAsync();
        }
    }
}
