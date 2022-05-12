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
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                    .OrderBy(e => e.BusinessEntityId)
                    .ToListAsync();

        public async Task<Employee> GetEmployeesAsync(int id, bool trackChanges) =>
            await FindByCondition(e => e.BusinessEntityId.Equals(id), trackChanges).SingleOrDefaultAsync();

        /*public async Task<IEnumerable<Employee>> SearchEmployee(EmployeeParameters employeeParameters, bool trackChanges)
        {
            if (string.IsNullOrWhiteSpace(employeeParameters.SearchEmployee))
            {
                return await FindAll(trackChanges).ToListAsync();
            }

            var lowerCaseResult = employeeParameters.SearchEmployee.Trim().ToLower();
            return await FindAll(trackChanges)
                            .Where(e => e.)
        }*/
    }
}
