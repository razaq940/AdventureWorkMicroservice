using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.Contracts;
using Sales.Entities.DTO;
using Sales.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.WebApi.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SalesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTerritory()
        {
            try
            {
                var salesTerritory = await _repository.SalesTerritory.GetAllSalesTerritoryAsync(trackChanges : false);

                var salesTerritoryDto = _mapper.Map<IEnumerable<SalesTerritoryDto>>(salesTerritory);

                return Ok(salesTerritoryDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetTerritory)} message : {ex}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("territoryId")]
        public async Task<IActionResult> GetTerritorySearch([FromQuery] SalesTerritoryParameters salesTerritoryParameters)
        {
            var salesTerritory = await _repository.SalesTerritory.SearchTerritory(salesTerritoryParameters, trackChanges: false);

            var salesTerritoryDto = _mapper.Map<SalesTerritoryDto>(salesTerritory);
            return Ok(salesTerritoryDto);
        }
    }
}
