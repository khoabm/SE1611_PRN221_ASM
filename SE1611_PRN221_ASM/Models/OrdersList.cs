namespace SE1611_PRN221_ASM.Models
{
    public class OrdersList
    {
        public int OrderId { get; set; } = 0!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public short? Status { get; set; }
        public DateTime? PlaceDate { get; set; }

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
    }
}
