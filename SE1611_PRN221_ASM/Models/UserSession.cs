namespace SE1611_PRN221_ASM.Models
{
    public class UserSession
    {
        public String Email { get; set; } = null!;
        public String Password { get; set; } = null!;
        public String FullName { get; set; } = null!;
        public String Gender { get; set; } = null!;
        public DateTime? BirthDay { get; set; }
        public short Status { get; set; }
        public int RoleId { get; set; }
        public int AccountType { get; set; }
        public int CartItemCount { get; set; }
        public int FavoriteItemCount { get; set; }
    }
}
