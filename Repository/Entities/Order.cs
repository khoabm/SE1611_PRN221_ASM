using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public short? Status { get; set; }

    public DateTime? PlaceDate { get; set; }

    public double? TotalAmount { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    
}
