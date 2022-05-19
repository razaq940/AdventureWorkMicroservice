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

        [HttpGet]
        public async Task<IActionResult> GetSalesOrderDetail(int salesOrderId, int salesOrderDetailId)
        {
            try
            {
                var salesOrderDetail = await _repository.SalesOrderDetail.GetSalesOrderDetailAsync(salesOrderId,salesOrderDetailId,trackChanges: false);

                return Ok(salesOrderDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PayByCardNumber(CardNumberDto cardNumberDto)
        {
            try
            {
                var cardNumber = await _cartItemCreateOrderService.CheckCardNumber(cardNumberDto);
                if (cardNumber == null)
                {
                    return NotFound();
                }
                return Ok($"{cardNumber.CardNumber} Valid");
            }
            catch (Exception ex)
            {
                _loggerManager.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
