﻿using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class BookGenre
{
    public int BookGenreId { get; set; }

    public int BookId { get; set; }

    public int GenreId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;
}
