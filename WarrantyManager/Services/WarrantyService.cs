using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarrantyManager.Data;
using WarrantyManager.Dtos;
using WarrantyManager.Models;

namespace WarrantyManager.Services
{
    public class WarrantyService : IWarrantyService
    {

        private readonly DbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<WarrantyService> _logger;

        public WarrantyService(IMapper mapper, ILogger<WarrantyService> logger, WarrantyManagementDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        public async Task<CustomerDTO> CreateCustomerAsync(CustomerDTO obj)
        {
            
            var customer = _mapper.Map<Customer>(obj);
            try
            {
                _context.Set<Customer>().Add(customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return _mapper.Map<CustomerDTO>(customer);
        }
        public async Task<List<CustomerDTO>> GetCustomersAsync(string customerName = null, Guid? customerId = null)
        {
            var response = new List<CustomerDTO>();
            try
            {

                var customerSearch = _context.Set<Customer>();

                if (customerName != null )
                {
                    customerSearch.Where(s => s.Name == customerName);
                }

                if (customerId != Guid.Empty && customerId != null)
                {
                    customerSearch.Where(s => s.Id == customerId);
                }

                var cust = await customerSearch.Include(s => s.Warranties).ToListAsync();


                response = _mapper.Map<List<CustomerDTO>>(cust);

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;

        }
        public async Task<List<DistributorDTO>> GetDistributorsAsync(string distributorName = null, Guid? distributorId = null)
        {
            var response = new List<DistributorDTO>();
            try
            {

                var distributorSearch = _context.Set<Distributor>();

                if (distributorName != null)
                {
                    distributorSearch.Where(s => s.Name == distributorName);
                }

                if (distributorId != Guid.Empty && distributorId != null)
                {
                    distributorSearch.Where(s => s.Id == distributorId);
                }

            
                var distributors = await distributorSearch.Include(s => s.Customers).Include("Customers.Warranties").ToListAsync();


                response = _mapper.Map<List<DistributorDTO>>(distributors);

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;

        }
        public async Task<CustomerDTO> UpdateCustomerAsync(CustomerDTO obj, Guid customerId)
        {
            var customer = _mapper.Map<Customer>(obj);
            try
            {
                _context.Set<Customer>().Update(customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return _mapper.Map<CustomerDTO>(customer);
        }


    }

}
