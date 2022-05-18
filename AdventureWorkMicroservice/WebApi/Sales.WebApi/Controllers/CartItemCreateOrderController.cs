using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.Contracts;
using Sales.Entities.DTO;
using System;
using System.Threading.Tasks;

namespace Sales.WebApi.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class CartItemCreateOrderController : Controller
    {
        private IRepositoryManager _repository;
        private ICartItemCreateOrderService _cartItemCreateOrderService;
        private ILoggerManager _loggerManager;
        private IMapper _mapper;

        public CartItemCreateOrderController(IRepositoryManager repository, ICartItemCreateOrderService cartItemCreateOrderService, ILoggerManager loggerManager, IMapper mapper)
        {
            _repository = repository;
            _cartItemCreateOrderService = cartItemCreateOrderService;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        [HttpGet("shipped/{id}")]
        public async Task<IActionResult> GetShipped(int id)
        {
            var shipped = await _repository.ShipMethod.GetShipMethodAsync(id, trackChanges: true);

            var shippedDto = _mapper.Map<ShipMethodDto>(shipped);
            return Ok(shippedDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddShipMethod(int id,[FromBody] ShipMethodDto shipMethodDto)
        {
            try
            {
                var shipper = _cartItemCreateOrderService.AddShipMethod(id, shipMethodDto);
                if(shipper == null)
                {
                    return BadRequest("Add Failed");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _loggerManager.LogWarn($"message : {ex.Message}");
                return BadRequest(ex.Message);
            }
            
        }
    }
}
