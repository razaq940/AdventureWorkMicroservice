using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Contracts.Interface
{
    public interface IShipMethodRepository
    {
        Task<IEnumerable<ShipMethod>> GetAllShipMethodAsync(bool trackChanges);
        Task<ShipMethod> GetShipMethodAsync(int id, bool trackChanges);
        void CreateShipMethod(ShipMethod shipMethod);
        void UpdateShipMethod(ShipMethod shipMethod);
        void DeleteShipMethod(ShipMethod shipMethod);
    }
}
