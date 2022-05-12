using Sales.Entities.Models;
using Sales.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeeAsync(bool trackChanges);
        Task<Employee> GetEmployeesAsync(int id, bool trackChanges);
        //Task<IEnumerable<Employee>> SearchEmployee(EmployeeParameters employeeParameters, bool trackChanges);
    }
}
