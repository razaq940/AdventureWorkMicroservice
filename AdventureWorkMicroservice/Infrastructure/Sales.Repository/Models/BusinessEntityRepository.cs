using Microsoft.EntityFrameworkCore;
using Sales.Contracts.Interface;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repository.Models
{
    public class BusinessEntityRepository : RepositoryBase<BusinessEntity>, IBusinessEntityRepository
    {
        public BusinessEntityRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateBusinessEntity(BusinessEntity businessEntity)
        {
            Create(businessEntity);
        }

        public void DeleteBusinessEntity(BusinessEntity businessEntity)
        {
            Delete(businessEntity);
        }

        public async Task<BusinessEntity> GetBusinessEntityAsnyc(int id, bool trackChanges) =>
            await FindByCondition(be => be.BusinessEntityId.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateBusinessEntity(BusinessEntity businessEntity)
        {
            Update(businessEntity);
        }
    }
}
