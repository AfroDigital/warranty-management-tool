using AutoMapper;
using WarrantyManager.Dtos;
using WarrantyManager.Models;

namespace WarrantyManager.Utils
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
            CreateMap<Warranty, WarrantyDTO>().ReverseMap();
            CreateMap<Distributor, DistributorDTO>().ReverseMap();

        }
    }
}
