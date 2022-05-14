using Sales.Entities.Models;
using Sales.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface
{
    public interface IVEmployeePersonRepository
    {
        Task<IEnumerable<vEmployeePerson>> GetAllVEmployeePersonAsync(bool trackChanges);
        Task<vEmployeePerson> GetVEmployeePersonAsync(int id, bool trackChanges);
        void CreateVEmployeePerson(vEmployeePerson vEmployeePerson);
        void UpdateVEmployeePerson(vEmployeePerson vEmployeePerson);
        void DeleteVEmployeePerson(vEmployeePerson vEmployeePerson);
        Task<IEnumerable<vEmployeePerson>> SearchEmployeePerson(EmployeePersonParameters employeePersonParameters, bool trackChanges);
    }
}
