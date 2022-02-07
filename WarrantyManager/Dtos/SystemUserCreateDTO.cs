namespace WarrantyManager.Dtos
{
    public class SystemUserCreateDTO : SystemUserDTO
    {
  
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }

}
