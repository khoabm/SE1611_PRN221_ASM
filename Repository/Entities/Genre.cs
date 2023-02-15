using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<BookGenre> BookGenres { get; } = new List<BookGenre>();
}
