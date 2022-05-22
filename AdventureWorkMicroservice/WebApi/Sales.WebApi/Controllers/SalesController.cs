using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.Contracts;
using Sales.Entities.DTO;
using Sales.Entities.Models;
using Sales.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.WebApi.Controllers
{
    [Route("api/sales/[action]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IAddEditSalesPersonService _addEditSalesPersonService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SalesController(IRepositoryManager repository, IAddEditSalesPersonService addEditSalesPersonService, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _addEditSalesPersonService = addEditSalesPersonService;
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

        [HttpGet("territoryId/{id}")]
        public async Task<IActionResult> GetTerritorySearch(int id)
        {
            var salesTerritory = await _repository.SalesTerritory.GetSalesTerritory(id, trackChanges: true);

            var salesTerritoryDtos = _mapper.Map<SalesTerritoryDto>(salesTerritory);
            return Ok(salesTerritoryDtos);
        }

        [HttpGet("store/{name}")]
        public async Task<IActionResult> GetStoreSearch(string name)
        {
            try
            {
                var store = await _repository.Store.GetStoreAsync(name, trackChanges: true);
                if (store == null)
                {
                    return NotFound();
                }
                var storeDto = _mapper.Map<StoreDto>(store);
                return Ok(storeDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> AddStoreSalesPerson(StoreDto storeDto)
        {
            try
            {
                var addStore = await _addEditSalesPersonService.AddStoreAsync(storeDto);
                if (addStore == null)
                {
                    return BadRequest("Save Failed");
                }
                return Ok(addStore);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStoreSalesPerson(StoreDto storeDto)
        {
            var store = await _addEditSalesPersonService.DeleteStoreAsync(storeDto);

            if (store == null)
            {
                _logger.LogInfo($"Store Name with id : {store.Name} doesn't exist in database");
                return NotFound();
            }
            return Ok($"{store.Name} Delete success");
        }

        [HttpGet("search/employee")]
        public async Task<IActionResult> GetEmployeeNameSearch([FromQuery] EmployeePersonParameters employeePersonParameters)
        {
            var employeePerson = await _repository.EmployeePerson.SearchEmployeePerson(employeePersonParameters, trackChanges: false);

            var employeePersonDto = _mapper.Map<IEnumerable<VEmployeePersonDto>>(employeePerson);
            return Ok(employeePersonDto);
        }

        [HttpPost]
        public async Task<IActionResult> SaveSalesPerson([FromBody] AddEditSalesPersonDto addEditSalesPersonDto)
        {
            try
            {
                var result = await _addEditSalesPersonService.SaveSalesPerson(addEditSalesPersonDto);
                if (result == null)
                {
                    return BadRequest("Save Failed");
                }
                return Ok($"{result.BusinessEntityId} Success");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEditSalesPerson(int salesPersonId)
        {
            try
            {
                var result = await _addEditSalesPersonService.GetEditSalesPerson(salesPersonId);
                if (result == null)
                {
                    return NotFound();
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
