using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class Comment
{
    public int CommentId { get; set; }

    public string Content { get; set; } = null!;

    public double? Rating { get; set; }

    public DateTime? CommentDate { get; set; }

    public int BookId { get; set; }

    public int CustomerId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
