using System;
using System.Collections.Generic;

namespace WarrantyManager.Dtos
{
    public class CustomerDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public List<WarrantyDTO> Warranties { get; set; }

        public CustomerDTO()
        {
            Warranties = new List<WarrantyDTO>();
        }

    }

}
