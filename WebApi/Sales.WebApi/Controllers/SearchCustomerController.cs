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
    [Route("api/customer")]
    [ApiController]
    public class SearchCustomerController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public SearchCustomerController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCustomerSearch([FromQuery] CustomerParameters customerParameters)
        {
            var customerSearch = await _repository.Customers
                                .SearchCustomer(customerParameters, trackChanges: false);
            var customerDto = _mapper.Map<IEnumerable<CustomerDto>>(customerSearch);
            return Ok(customerDto);
        }

        /*[HttpGet("pagination")]
        public async Task<IActionResult> GetCustomerPagination([FromQuery] CustomerParameters customerParameters)
        {
            var customerPage = await _repository.Customers
                                .GetPaginationCustomerAsync(customerParameters, trackChanges: false);
            var customerDto = _mapper.Map<IEnumerable<CustomerDto>>(customerPage);
            return Ok(customerDto);
        }*/
    }
}
