using Microsoft.EntityFrameworkCore;
using Sales.Contracts.Interface.AECInterface;
using Sales.Entities.Contexts;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repository.Models
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreatePerson(Person person)
        {
            Create(person);
        }

        public void DeletePerson(Person person)
        {
            Delete(person);
        }

        public async Task<IEnumerable<Person>> GetAllPersonAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(c => c.FirstName)
                .ToListAsync();
        }

        public async Task<Person> GetPersonAsync(string name, bool trackChanges)
        {
            return await FindByCondition(c => (c.FirstName+c.MiddleName+c.LastName).Contains(name), trackChanges)
                .FirstOrDefaultAsync();
        }

        public void UpdatePerson(Person person)
        {
            Update(person);
        }
    }
}
