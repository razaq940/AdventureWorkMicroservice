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
    [Route("api/salesperson")]
    [ApiController]
    public class SearchSalesPersonController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public SearchSalesPersonController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetSalesPersonSearch([FromQuery] SalesPersonParameters salesPersonParameters)
        {
            var salesPersonSearch = await _repository.SPersons
                                .SearchSalesPerson(salesPersonParameters, trackChanges: false);
            var salesPersonDto = _mapper.Map<IEnumerable<SalesPersonDto>>(salesPersonSearch);
            return Ok(salesPersonDto);
        }

        /*[HttpGet("search")]
        public async Task<IActionResult> GetCustomerSearch([FromQuery] CustomerParameters customerParameters)
        {
            var customerSearch = await _repository.Customers
                                .SearchCustomer(customerParameters, trackChanges: false);
            var customerDto = _mapper.Map<IEnumerable<CustomerDto>>(customerSearch);
            return Ok(customerDto);
        }*/
    }
}
