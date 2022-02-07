using System;
using WarrantyManager.Models;

namespace WarrantyManager.Dtos
{
    public class WarrantyDTO
    {
        public Guid? CustomerId { get; set; }
        public string SerialNumber { get; set; }
        public bool IsWarrantied { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
        public string ProductName { get; set; }


    }

}
