#nullable disable

using System;

namespace WarrantyManager.Models
{
    public partial class SystemUser : BaseEntity
    {
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
    }
}
