using Sales.Contracts;
using Sales.Entities.DTO;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repository.Models
{
    public class CartItemCreateOrderService : ICartItemCreateOrderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public CartItemCreateOrderService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> AddShipMethod(int id, ShipMethodDto shipMethodDto)
        {
            try
            {
                var shipps = await _repositoryManager.ShipMethod.GetShipMethodAsync(shipMethodDto.ShipMethodId, trackChanges: true);
                var orderHeader = await _repositoryManager.SalesOrderHeader.GetSalesOrderHeaderAsync(id, trackChanges: true);
                if (orderHeader == null)
                {
                    SalesOrderHeader salesOrderHeader = new SalesOrderHeader();

                    salesOrderHeader.ShipMethodId = shipMethodDto.ShipMethodId; 

                    _repositoryManager.SalesOrderHeader.UpdateSalesOrderHeader(salesOrderHeader);
                    await _repositoryManager.SaveAsync();

                }
                return true;
            }
            catch (Exception ex)
            {
                _loggerManager.LogWarn($"message : {ex.Message}");
                return false;
            }
        }
    }
}
