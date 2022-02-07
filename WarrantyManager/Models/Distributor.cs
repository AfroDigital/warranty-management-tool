using System;
using System.Collections.Generic;

#nullable disable

namespace WarrantyManager.Models
{
    public partial class Distributor : BaseEntity
    {
        public Distributor()
        {
            Customers = new HashSet<Customer>();
            Users = new HashSet<SystemUser>();

        }

        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<SystemUser> Users { get; set; }

    }
}
