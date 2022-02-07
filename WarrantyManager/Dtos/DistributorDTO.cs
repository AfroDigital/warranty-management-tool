using System;
using System.Collections.Generic;

namespace WarrantyManager.Dtos
{
    public class DistributorDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public List<CustomerDTO> Customers { get; set; }
        public List<SystemUserDTO> Users { get; set; }


        public DistributorDTO()
        {
            Customers = new List<CustomerDTO>();
            Users = new List<SystemUserDTO>();
        }

    }

}
