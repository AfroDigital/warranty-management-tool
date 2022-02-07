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
    [Route("api/v1/distributors")]
    public class DistributorsController : ControllerBase
    {
        private readonly IWarrantyService _warrantyService;
        private readonly ILogger<DistributorsController> _logger;


        public DistributorsController(ILogger<DistributorsController> logger, IWarrantyService warrantyService)
        {
            _warrantyService = warrantyService ?? throw new ArgumentNullException(nameof(warrantyService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));


        }


        [HttpGet("")]
        [ProducesResponseType(typeof(List<DistributorDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<DistributorDTO>), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetCustomer(
                 [FromQuery(Name = "distributorName")] string distributorName,
                 [FromQuery(Name = "distributorId")] Guid? distributorId
                 )
        {


            var result = await _warrantyService.GetDistributorsAsync(distributorName, distributorId);
            if (result == null)
            {
                return NoContent();
            }


            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(DistributorDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(DistributorDTO), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {

            var result = await _warrantyService.GetDistributorsAsync(distributorId: id);
            if (result == null)
            {
                return NoContent();
            }


            return Ok(result[0]);
        }
    

    }
}
