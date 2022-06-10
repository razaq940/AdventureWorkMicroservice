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
        private readonly IProductOnSaleService _productOnSaleService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductOnSaleControllers(IRepositoryManager repository, IProductOnSaleService productOnSaleService, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _productOnSaleService = productOnSaleService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddToCart([FromBody] AddToCartDto addToCartDto)
        {
            try
            {
                var result = await _productOnSaleService.AddToCartProduct(addToCartDto);
                if(result == null)
                {
                    return BadRequest("Add Failed");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
