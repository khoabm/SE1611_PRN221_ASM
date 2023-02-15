using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class Cart
{
    public int CartId { get; set; }

    public int? Quantity { get; set; }

    public int BookId { get; set; }

    public int CustomerId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
