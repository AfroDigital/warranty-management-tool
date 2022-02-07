using System;

#nullable disable

namespace WarrantyManager.Models
{
    public partial class Warranty
    {
        public virtual Guid CustomerId { get; set; }
        public string SerialNumber { get; set; }
        public bool IsWarrantied { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
        public virtual Customer Customer { get; set; }
        public string ProductName { get; set; }
    }
}
