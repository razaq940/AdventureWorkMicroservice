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
    public class VEmployeePersonRepository : RepositoryBase<vEmployeePerson>, IVEmployeePersonRepository
    {
        public VEmployeePersonRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateVEmployeePerson(vEmployeePerson vEmployeePerson)
        {
            Create(vEmployeePerson);
        }

        public void DeleteVEmployeePerson(vEmployeePerson vEmployeePerson)
        {
            Delete(vEmployeePerson);
        }

        public async Task<IEnumerable<vEmployeePerson>> GetAllVEmployeePersonAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                    .OrderBy(ep => ep.BusinessEntityID)
                    .ToListAsync();

        public async Task<vEmployeePerson> GetVEmployeePersonAsync(int id, bool trackChanges) =>
            await FindByCondition(ep => ep.BusinessEntityID.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<vEmployeePerson>> SearchEmployeePerson(EmployeePersonParameters employeePersonParameters, bool trackChanges)
        {
            if (string.IsNullOrWhiteSpace(employeePersonParameters.SearchEmployeeName))
            {
                return await FindAll(trackChanges).ToListAsync();
            }

            var lowerCaseResult = employeePersonParameters.SearchEmployeeName.Trim().ToLower();
            return await FindAll(trackChanges)
                            .Where(st => st.FullName.ToLower().Contains(lowerCaseResult))
                            .OrderBy(st => st.BusinessEntityID)
                            .ToListAsync();
        }

        public void UpdateVEmployeePerson(vEmployeePerson vEmployeePerson)
        {
            Update(vEmployeePerson);
        }
    }
}
