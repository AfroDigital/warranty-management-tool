using System;
using System.Collections.Generic;

#nullable disable

namespace WarrantyManager.Models
{
    public partial class Customer : BaseEntity
    {
        public Customer()
        {
            Warranties = new HashSet<Warranty>();
        }


        public string Name { get; set; }

        public virtual ICollection<Warranty> Warranties { get; set; }
    }
}
