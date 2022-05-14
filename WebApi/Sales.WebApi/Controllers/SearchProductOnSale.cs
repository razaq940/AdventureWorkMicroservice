using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Contracts;
using Sales.Entities.DTO;
using Sales.Entities.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.WebApi.Controllers
{
    [Route("api/ProdOnSale")]
    [ApiController]
    public class SearchProductOnSale : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public SearchProductOnSale(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetProdOnSaleSearch([FromQuery] ProductOnSaleParameters prodOnSaleParameters)
        {
            var prodOnSaleSearch = await _repository.ProdOnSale
                                .SearchProductOnSale(prodOnSaleParameters, trackChanges: false);
            var prodOnSaleDto = _mapper.Map<IEnumerable<ProdOnSaleDto>>(prodOnSaleSearch);
            return Ok(prodOnSaleDto);
        }
    }
}
