using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.Contracts;
using Sales.Entities.DTO;
using System;
using System.Threading.Tasks;

namespace Sales.WebApi.Controllers
{
    [Route("api/product/[action]")]
    [ApiController]
    public class ProductOnSaleControllers : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IAddEditSalesPersonService _addEditSalesPersonService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductOnSaleControllers(IRepositoryManager repository, IAddEditSalesPersonService addEditSalesPersonService, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _addEditSalesPersonService = addEditSalesPersonService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddToCart([FromBody] AddToCartDto addToCartDto)
        {
            try
            {
                var result = await _addEditSalesPersonService.AddToCartProduct(addToCartDto);
                if(!result)
                {
                    return BadRequest("Add Failed");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
