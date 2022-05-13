using Sales.Contracts.Interface;
using Sales.Entities.Models;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.Entities.Models;
using Sales.Contracts.Interface.AECInterface;
using Sales.Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Sales.Entities.RequestFeatures;

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

        public void DeleteStore(BusinessEntity businessEntity)
        {
            Delete(businessEntity);
        }

        public void UpdateStore(BusinessEntity businessEntity)
        {
            Update(businessEntity);
        }
    }
}
