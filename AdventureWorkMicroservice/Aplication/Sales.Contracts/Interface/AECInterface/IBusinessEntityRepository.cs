using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface.AECInterface
{
    public interface IBusinessEntityRepository
    {
       
        void CreateBusinessEntity(BusinessEntity businessEntity);

        void DeleteStore(BusinessEntity businessEntity);
        void UpdateStore(BusinessEntity businessEntity);
    }
}
