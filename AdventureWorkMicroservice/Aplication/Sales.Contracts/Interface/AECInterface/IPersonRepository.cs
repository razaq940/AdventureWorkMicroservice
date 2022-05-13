using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface.AECInterface
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersonAsync(bool trackChanges);

        Task<Person> GetPersonAsync(string name, bool trackChanges);

        void CreatePerson(Person person);

        void DeletePerson(Person person);
        void UpdatePerson(Person person);
    }
}
