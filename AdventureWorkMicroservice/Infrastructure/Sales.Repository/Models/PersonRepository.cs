using Microsoft.EntityFrameworkCore;
using Sales.Contracts.Interface;
using Sales.Entities.Models;
using Sales.Entities.RequestFeatures;
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

        public async Task<IEnumerable<Person>> GetAllPersonAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                    .OrderBy(p => p.BusinessEntityId)
                    .ToListAsync();

        public async Task<Person> GetPersonAsync(int id, bool trackChanges) =>
            await FindByCondition(p => p.BusinessEntityId.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Person>> SearchPerson(PersonParameters personParameters, bool trackChanges)
        {
            if (string.IsNullOrWhiteSpace(personParameters.SearchName))
            {
                return await FindAll(trackChanges).ToListAsync();
            }
            var lowerCaseResult = personParameters.SearchName.Trim().ToLower();
            return await FindAll(trackChanges)
                            .Where(p => (p.FirstName + p.MiddleName + p.LastName).ToLower().Contains(lowerCaseResult))
                            .OrderBy(p => p.BusinessEntityId)
                            .ToListAsync();
        }
    }
}
