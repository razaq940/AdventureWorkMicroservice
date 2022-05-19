using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface
{
    public interface ICreditCardRepository
    {
        Task<IEnumerable<CreditCard>> GetAllCreditCardAsync(bool trackChanges);
        Task<CreditCard> GetCreditCardAsync(string id, bool trackChanges);
    }
}
