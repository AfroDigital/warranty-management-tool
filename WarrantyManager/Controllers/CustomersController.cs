using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WarrantyManager.Dtos;
using WarrantyManager.Services;

namespace WarrantyManager.Controllers
{
    [ApiController]
    [Route("api/v1/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IWarrantyService _warrantyService;
        private readonly ILogger<CustomersController> _logger;


        public CustomersController(ILogger<CustomersController> logger, IWarrantyService warrantyService)
        {
            _warrantyService = warrantyService ?? throw new ArgumentNullException(nameof(warrantyService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));


        }


        [HttpGet("")]
        [ProducesResponseType(typeof(List<CustomerDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<CustomerDTO>), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetCustomer(
                 [FromQuery(Name = "customerName")] string customerName,
                 [FromQuery(Name = "customerId")] Guid? customerId
                 )
        {


            var result = await _warrantyService.GetCustomersAsync(customerName, customerId);
            if (result == null)
            {
                return NoContent();
            }


            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(CustomerDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CustomerDTO), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {

            var result = await _warrantyService.GetCustomersAsync(customerId: id);
            if (result == null)
            {
                return NoContent();
            }


            return Ok(result[0]);
        }
        [HttpPost("")]
        [ProducesResponseType(typeof(CustomerDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CustomerDTO), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDTO value)
        {

            var result = await _warrantyService.CreateCustomerAsync(value);
            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(CustomerDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CustomerDTO), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDTO value, Guid id)
        {

            var result = await _warrantyService.UpdateCustomerAsync(value,id);
            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

      
    }

}
