namespace SE1611_PRN221_ASM.Models
{
    public class UserSession
    {
        public String Email { get; set; } = null!;
        public String Password { get; set; } = null!;
        public String FullName { get; set; } = null!;
        public String Gender { get; set; } = null!;
        public String? BirthDay { get; set; }

        public int RoleId { get; set; }


        public int CartItemCount { get; set; }

    }
}
