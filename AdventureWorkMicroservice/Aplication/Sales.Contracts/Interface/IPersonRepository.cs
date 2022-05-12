using Sales.Entities.Models;
using Sales.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersonAsync(bool trackChanges);
        Task<Person> GetPersonAsync(int id, bool trackChanges);
        Task<IEnumerable<Person>> SearchPerson(PersonParameters personParameters, bool trackChanges);
    }
}
