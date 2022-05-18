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
    public class ShipMethodRepository : RepositoryBase<ShipMethod>, IShipMethodRepository
    {
        public ShipMethodRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateShipMethod(ShipMethod shipMethod)
        {
            Create(shipMethod);
        }

        public void DeleteShipMethod(ShipMethod shipMethod)
        {
            Delete(shipMethod);
        }

        public async Task<IEnumerable<ShipMethod>> GetAllShipMethodAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                    .OrderBy(sm => sm.ShipMethodId)
                    .ToListAsync();

        public async Task<ShipMethod> GetShipMethodAsync(int id, bool trackChanges) =>
            await FindByCondition(sm => sm.ShipMethodId.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateShipMethod(ShipMethod shipMethod)
        {
            Update(shipMethod);
        }
    }
}
