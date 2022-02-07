using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarrantyManager.Dtos;

namespace WarrantyManager.Services
{
    public interface IWarrantyService
    {
        Task<CustomerDTO> CreateCustomerAsync(CustomerDTO obj);
        Task<List<CustomerDTO>> GetCustomersAsync(string customerName = null,  Guid? customerId = null);
        Task<CustomerDTO> UpdateCustomerAsync(CustomerDTO obj, Guid customerId);
        Task<List<DistributorDTO>> GetDistributorsAsync(string distributorName = null, Guid? distributorId = null);
    }

   

}
