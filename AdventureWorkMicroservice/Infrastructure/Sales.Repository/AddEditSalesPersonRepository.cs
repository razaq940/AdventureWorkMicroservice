using Sales.Contracts;
using Sales.Entities.DTO;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repository
{
    public class AddEditSalesPersonRepository : IAddEditSalesPersonService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AddEditSalesPersonRepository(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public Task<SalesTerritory> SearchSalesTerritoryById(int territoryId)
        {
            throw new NotImplementedException();
        }

        /*public async Task<SalesPerson> AddEditSalesPersonAsync(AddEditSalesPersonDto addEditSalesPersonDto, bool trackChanges)
        {
            
            try
            {
                var employees = await _repositoryManager.Employee.GetEmployeesAsync(addEditSalesPersonDto.BusinessEntityId, trackChanges: true);
                var person = await _repositoryManager.Person.GetPersonAsync(addEditSalesPersonDto.BusinessEntityId, trackChanges: true);
                var salesTerritory = await _repositoryManager.SalesTerritory.GetSalesTerritory(addEditSalesPersonDto.BusinessEntityId, trackChanges: true);
                if (employees != null)
                {
                    employees.NationalIdnumber = addEditSalesPersonDto.NationalIdnumber;
                    employees.JobTitle = addEditSalesPersonDto.JobTitle;
                    person.FirstName = addEditSalesPersonDto.FirstName;
                    person.MiddleName = addEditSalesPersonDto.MiddleName;
                    person.LastName = addEditSalesPersonDto.LastName;
                    salesTerritory.

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }*/
    }
}
