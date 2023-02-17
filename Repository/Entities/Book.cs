using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class Book
{
    public int BookId { get; set; }

    public string? Author { get; set; }

    public string? Description { get; set; }

    public string? ImageLink { get; set; }

    public double? Price { get; set; }

    public string? Publisher { get; set; }

    public int? QuantityLeft { get; set; }

    public short? Status { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<BookGenre> BookGenres { get; } = new List<BookGenre>();

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Favorite> Favorites { get; } = new List<Favorite>();

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
