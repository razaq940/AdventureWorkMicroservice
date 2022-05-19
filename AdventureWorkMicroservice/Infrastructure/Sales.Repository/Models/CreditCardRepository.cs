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
    public class CreditCardRepository : RepositoryBase<CreditCard>, ICreditCardRepository
    {
        public CreditCardRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<CreditCard>> GetAllCreditCardAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                    .OrderBy(cc => cc.CreditCardId)
                    .ToListAsync();

        public async Task<CreditCard> GetCreditCardAsync(string id, bool trackChanges) =>
            await FindByCondition(cc => cc.CardNumber.Contains(id), trackChanges).SingleOrDefaultAsync();
    }
}
