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
    public class PersonCreditCardRepository : RepositoryBase<PersonCreditCard>, IPersonCreditCardRepository
    {
        public PersonCreditCardRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<PersonCreditCard>> GetAllPersonCreditCardAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                    .OrderBy(pc => pc.CreditCardId)
                    .ToListAsync();

        public async Task<PersonCreditCard> GetPersonCreditCardAsync(int id, bool trackChanges) =>
            await FindByCondition(pc => pc.CreditCardId.Equals(id), trackChanges).SingleOrDefaultAsync();
    }
}
