﻿using AutoMapper;
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
            var store = await _repository.Store.GetStoreAsync(name, trackChanges: true);

            var storeDto = _mapper.Map<StoreDto>(store);
            return Ok(storeDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStore([FromBody]StoreDto storeDto)
        {
            if (storeDto == null)
            {
                _logger.LogError("Store Name object is null");
                return BadRequest("Store Name object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid modelstate storeDto");
                return UnprocessableEntity(ModelState);
            }

            var store = _mapper.Map<Store>(storeDto);
            _repository.Store.CreateStoreAsync(store);
            await _repository.SaveAsync();

            return Ok(_mapper.Map<StoreDto>(store));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            var store = await _repository.Store.GetStoreByIdAsync(id, trackChanges: false);

            if (store == null)
            {
                _logger.LogInfo($"Store Name with id : {id} doesn't exist in database");
                return NotFound();
            }

            _repository.Store.DeleteStoreAsync(store);
            await _repository.SaveAsync();
            return NoContent();
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

    }
}
