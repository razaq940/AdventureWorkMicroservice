using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface
{
    public interface IPersonCreditCardRepository
    {
        Task<IEnumerable<PersonCreditCard>> GetAllPersonCreditCardAsync(bool trackChanges);
        Task<PersonCreditCard> GetPersonCreditCardAsync(int id, bool trackChanges);
    }
}
