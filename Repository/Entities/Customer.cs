using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities;

public partial class Customer
{
    public int CustomerId { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Gender { get; set; }

    public string? Name { get; set; }

    public short? Status { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual Account CustomerNavigation { get; set; } = null!;

    public virtual ICollection<Favorite> Favorites { get; } = new List<Favorite>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
