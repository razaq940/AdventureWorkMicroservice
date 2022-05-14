using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface
{
    public interface IBusinessEntityRepository
    {
        Task<BusinessEntity> GetBusinessEntityAsnyc(int id, bool trackChanges);
        void CreateBusinessEntity(BusinessEntity businessEntity);
        void UpdateBusinessEntity(BusinessEntity businessEntity);
        void DeleteBusinessEntity(BusinessEntity businessEntity);
    }
}
