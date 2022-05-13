using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Contracts;
using System;
using System.Threading.Tasks;
using System.Linq;
using Sales.Entities.DTO.AECDTO;
using AutoMapper;
using System.Collections.Generic;
using Sales.Entities.Models;
using Sales.Contracts.Interface;
using Sales.Entities.Contexts;

namespace Sales.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AddEditCustomersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IAddEditCustomersService _addEditCustomersService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        

        public AddEditCustomersController(IRepositoryManager repository, IAddEditCustomersService addEditCustomersService, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _addEditCustomersService = addEditCustomersService;
            _logger = logger;
            _mapper = mapper;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetSalesTeritory(int teritoryId)
        {
            try
            {
                var result = await _addEditCustomersService.SearchSalesTeritoryByTeritoryId(teritoryId);
                if (result == null)
                {

                    return BadRequest("teritoryId Not Found");
                }
                return Ok(_mapper.Map<IEnumerable<SalesTeritoryAECDTO>>(result));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStoreByPersonId(int personId)
        {
            try
            {
                var result = await _addEditCustomersService.SearchStoreByPersonId(personId);
                if(result == null)
                {
                    return BadRequest("PersonID Not Found");
                }
                return Ok(_mapper.Map<IEnumerable<StoreAECDTO>>(result));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonByName(string name)
        {
            try
            {
                var result =await _addEditCustomersService.SearchPersonByName(name);
                if(result == null)
                {
                    _logger.LogError("person name not found");
                    return BadRequest("person name not found");
                }
                return Ok(_mapper.Map<IEnumerable<PersonAECDTO>>(result));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
